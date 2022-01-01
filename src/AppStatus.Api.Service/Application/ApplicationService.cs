using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AppStatus.Api.Framework;
using AppStatus.Api.Framework.Constants;
using AppStatus.Api.Framework.Exceptions;
using AppStatus.Api.Framework.Services.Application;
using AppStatus.Api.Service.Application.Models;
using AppStatus.Api.Service.Company;
using AppStatus.Api.Service.Employee;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace AppStatus.Api.Service.Application
{
    public class ApplicationService : IApplicationService
    {
        private readonly IOptionsMonitor<ApplicationOptions> _options;

        private readonly IMongoCollection<Domain.Application> _applicationCollection;
        private readonly IMongoCollection<Domain.Company> _companyCollection;
        private readonly IMongoCollection<Domain.Employee> _employeeCollection;
        private readonly IMongoCollection<Domain.Object> _objectCollection;

        private readonly MongoClient _mongoClient;


        public ApplicationService(IOptionsMonitor<ApplicationOptions> options)
        {
            _options = options;

            _mongoClient = new MongoClient(
            options.CurrentValue.ConnectionString);

            var mongoDatabase = _mongoClient.GetDatabase(
                options.CurrentValue.DatabaseName);

            _applicationCollection = mongoDatabase.GetCollection<Domain.Application>("Application");
            _companyCollection = mongoDatabase.GetCollection<Domain.Company>("Company");
            _employeeCollection = mongoDatabase.GetCollection<Domain.Employee>("Employee");
            _objectCollection = mongoDatabase.GetCollection<Domain.Object>("Object");
        }

        public async Task<string> FullCreateAsync(string accountId, IFullCreate model, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(model.Company.Name.Trim()))
                throw new ValidationException("100", "Company's name is required.");

            if (string.IsNullOrEmpty(model.Company.Url.Trim()))
                throw new ValidationException("100", "Company's url is required.");

            foreach (var employee in model.Employees)
                if (string.IsNullOrEmpty(employee.Name.Trim()))
                    throw new ValidationException("100", "Employee's name is required.");

            if (string.IsNullOrEmpty(model.ApplySource.Trim()))
                throw new ValidationException("100", "Applied from address field is required.");

            if (string.IsNullOrEmpty(model.ResumeId.Trim()))
                throw new ValidationException("100", "Resume id is required.");

            if (string.IsNullOrEmpty(model.CoverLetterId.Trim()))
                throw new ValidationException("100", "Cover letter id is required.");

            var resume = await _objectCollection.Find(x => x.Id == model.ResumeId).FirstOrDefaultAsync(cancellationToken);
            if (resume == null)
                throw new ValidationException("100", "Resume not found.");

            var coverLetter = await _objectCollection.Find(x => x.Id == model.CoverLetterId).FirstOrDefaultAsync(cancellationToken);
            if (coverLetter == null)
                throw new ValidationException("100", "Coverletter not found.");

            foreach (var employee in model.Employees)
            {
                if (string.IsNullOrEmpty(employee.PictureId))
                    continue;

                var picture = await _objectCollection.Find(x => x.Id == employee.PictureId).FirstOrDefaultAsync(cancellationToken);
                if (picture == null)
                    throw new ValidationException("100", "Employee's picture not found.");
            }

            var company = new Domain.Company()
            {
                RecordInsertDate = DateTime.Now,
                RecordLastEditDate = DateTime.Now,
                RecordStatus = RecordStatus.Inserted,
                Address = model.Company.Address,
                CreatorAccountId = accountId,
                Emails = model.Company.Emails,
                Name = model.Company.Name,
                PhoneNumbers = model.Company.PhoneNumbers,
                Url = model.Company.Url
            };

            await _companyCollection.InsertOneAsync(company, new InsertOneOptions(), cancellationToken);

            foreach (var employee in model.Employees)
            {
                var newEmployee = new Domain.Employee()
                {
                    RecordInsertDate = DateTime.Now,
                    RecordLastEditDate = DateTime.Now,
                    RecordStatus = RecordStatus.Inserted,
                    CompanyId = company.Id,
                    CreatorAccountId = accountId,
                    Email = employee.Email,
                    Name = employee.Name,
                    PhoneNumber = employee.PhoneNumber,
                    PictureId = employee.PictureId,
                    ProfileUrl = employee.ProfileUrl,
                    RoleId = employee.RoleId
                };

                await _employeeCollection.InsertOneAsync(newEmployee, new InsertOneOptions(), cancellationToken);
            }

            var application = new Domain.Application()
            {
                JobTitle = model.JobTitle,
                Salary = model.Salary,
                RecordInsertDate = DateTime.Now,
                RecordLastEditDate = DateTime.Now,
                RecordStatus = RecordStatus.Inserted,
                StateId = model.StateId,
                ApplySource = model.ApplySource,
                CompanyId = company.Id,
                CoverLetterId = model.CoverLetterId,
                CreatorAccountId = accountId,
                ResumeId = model.ResumeId,
                History = new[] { "Applied." }
            };

            await _applicationCollection.InsertOneAsync(application, new InsertOneOptions(), cancellationToken);

            return application.Id;
        }

        public async Task<IDashboardData> GetDashboardDataAsync(string accountId, CancellationToken cancellationToken)
        {
            var wishlistQuery = Builders<Domain.Application>.Filter.Where(x => x.StateId == State.Wishlist && x.CreatorAccountId == accountId && x.RecordStatus != RecordStatus.Deleted);
            var wishlist = await _applicationCollection.Find(wishlistQuery).Limit(_options.CurrentValue.MaximumItemsInDashboard).ToListAsync(cancellationToken);
            var totalWishlistCount = await _applicationCollection.Find(wishlistQuery).CountDocumentsAsync(cancellationToken);

            var appliedQuery = Builders<Domain.Application>.Filter.Where(x => x.StateId == State.Applied && x.CreatorAccountId == accountId && x.RecordStatus != RecordStatus.Deleted);
            var applied = await _applicationCollection.Find(appliedQuery).Limit(_options.CurrentValue.MaximumItemsInDashboard).ToListAsync(cancellationToken);
            var totalAppliedCount = await _applicationCollection.Find(appliedQuery).CountDocumentsAsync(cancellationToken);

            var interviewQuery = Builders<Domain.Application>.Filter.Where(x => x.StateId == State.Interview && x.CreatorAccountId == accountId && x.RecordStatus != RecordStatus.Deleted);
            var interview = await _applicationCollection.Find(interviewQuery).Limit(_options.CurrentValue.MaximumItemsInDashboard).ToListAsync(cancellationToken);
            var totalInterviewCount = await _applicationCollection.Find(interviewQuery).CountDocumentsAsync(cancellationToken);

            var offerQuery = Builders<Domain.Application>.Filter.Where(x => x.StateId == State.Offer && x.CreatorAccountId == accountId && x.RecordStatus != RecordStatus.Deleted);
            var offer = await _applicationCollection.Find(offerQuery).Limit(_options.CurrentValue.MaximumItemsInDashboard).ToListAsync(cancellationToken);
            var totalOfferCount = await _applicationCollection.Find(offerQuery).CountDocumentsAsync(cancellationToken);

            var rejectedQuery = Builders<Domain.Application>.Filter.Where(x => x.StateId == State.Offer && x.CreatorAccountId == accountId && x.RecordStatus != RecordStatus.Deleted);
            var rejected = await _applicationCollection.Find(rejectedQuery).Limit(_options.CurrentValue.MaximumItemsInDashboard).ToListAsync(cancellationToken);
            var totalRejectedCount = await _applicationCollection.Find(rejectedQuery).CountDocumentsAsync(cancellationToken);

            var companyIds = wishlist.Select(x => x.CompanyId)
                .Union(applied.Select(x => x.CompanyId))
                .Union(interview.Select(x => x.CompanyId))
                .Union(offer.Select(x => x.CompanyId))
                .Union(rejected.Select(x => x.CompanyId));

            var companies = await _companyCollection.Find(x => companyIds.Contains(x.Id)).ToListAsync(cancellationToken);
            var employees = await _employeeCollection.Find(x => companyIds.Contains(x.CompanyId)).ToListAsync(cancellationToken);

            var result = new DashboardDataModel()
            {
                Wishlist = new DashboardDataItemModel()
                {
                    Applications = ToModel(wishlist, companies, employees),
                    TotalApplications = totalWishlistCount
                },
                Applied = new DashboardDataItemModel()
                {
                    Applications = ToModel(applied, companies, employees),
                    TotalApplications = totalAppliedCount
                },
                Interview = new DashboardDataItemModel()
                {
                    Applications = ToModel(interview, companies, employees),
                    TotalApplications = totalInterviewCount
                },
                Offer = new DashboardDataItemModel()
                {
                    Applications = ToModel(offer, companies, employees),
                    TotalApplications = totalOfferCount
                },
                Rejected = new DashboardDataItemModel()
                {
                    Applications = ToModel(rejected, companies, employees),
                    TotalApplications = totalRejectedCount
                }
            };

            return result;
        }

        public static IEnumerable<IApplication> ToModel(IEnumerable<Domain.Application> applications, IEnumerable<Domain.Company> companies = null, IEnumerable<Domain.Employee> employees = null)
        {
            return applications.Select(application => new ApplicationModel()
            {
                JobTitle = application.JobTitle,
                Salary = application.Salary,
                Company = companies == null ? null : CompanyService.ToModel(companies.Where(company => application.CompanyId == company.Id)).FirstOrDefault(),
                Employees = employees == null ? null : EmployeeService.ToModel(employees.Where(employee => employee.CompanyId == application.CompanyId)),
                ApplySource = application.ApplySource,
                CoverLetterId = application.CoverLetterId,
                History = application.History,
                Id = application.Id,
                RecordInsertDate = application.RecordInsertDate,
                RecordLastEditDate = application.RecordLastEditDate,
                RecordStatus = application.RecordStatus,
                ResumeId = application.ResumeId,
                State = State.ToString(application.StateId),
                StateId = application.StateId
            });
        }
    }
}
