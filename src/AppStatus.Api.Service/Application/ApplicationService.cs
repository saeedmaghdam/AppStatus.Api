using System;
using System.Threading;
using System.Threading.Tasks;
using AppStatus.Api.Framework;
using AppStatus.Api.Framework.Constants;
using AppStatus.Api.Framework.Exceptions;
using AppStatus.Api.Framework.Services.Application;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace AppStatus.Api.Service.Application
{
    public class ApplicationService : IApplicationService
    {
        private readonly IMongoCollection<Domain.Application> _applicationCollection;
        private readonly IMongoCollection<Domain.Company> _companyCollection;
        private readonly IMongoCollection<Domain.Employee> _employeeCollection;
        private readonly IMongoCollection<Domain.Object> _objectCollection;

        private readonly MongoClient _mongoClient;


        public ApplicationService(IOptionsMonitor<ApplicationOptions> options)
        {
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
                RecordInsertDate = DateTime.Now,
                RecordLastEditDate = DateTime.Now,
                RecordStatus = RecordStatus.Inserted,
                State = State.Applied,
                ApplySource = model.ApplySource,
                CompanyId = company.Id,
                CoverLetterId = model.CoverLetterId,
                CreatorAccountId = model.CoverLetterId,
                ResumeId = model.ResumeId,
                History = new[] { "Applied." }
            };

            await _applicationCollection.InsertOneAsync(application, new InsertOneOptions(), cancellationToken);

            return application.Id;
        }
    }
}
