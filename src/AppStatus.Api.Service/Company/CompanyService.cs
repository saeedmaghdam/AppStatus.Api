using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AppStatus.Api.Framework;
using AppStatus.Api.Framework.Constants;
using AppStatus.Api.Framework.Services.Company;
using AppStatus.Api.Service.Company.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace AppStatus.Api.Service.Company
{
    public class CompanyService : ICompanyService
    {
        private readonly IMongoCollection<Domain.Company> _companyCollection;

        public CompanyService(IOptionsMonitor<ApplicationOptions> options)
        {
            var mongoClient = new MongoClient(
            options.CurrentValue.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                options.CurrentValue.DatabaseName);

            _companyCollection = mongoDatabase.GetCollection<Domain.Company>("Company");
        }

        public async Task<IEnumerable<ICompany>> GetAsync(CancellationToken cancellationToken)
        {
            var result = await _companyCollection.AsQueryable().ToListAsync(cancellationToken);

            return ToModel(result);
        }

        public async Task<string> CreateAsync(string accountId, string name, string url, string[] emails, string[] phoneNumbers, string address, CancellationToken cancellationToken)
        {
            var company = new Domain.Company()
            {
                RecordInsertDate = System.DateTime.Now,
                RecordLastEditDate = System.DateTime.Now,
                RecordStatus = RecordStatus.Inserted,
                Address = address,
                CreatorAccountId = accountId,
                Emails = emails,
                Name = name,
                PhoneNumbers = phoneNumbers,
                Url = url
            };

            await _companyCollection.InsertOneAsync(company, new InsertOneOptions(), cancellationToken);

            return company.Id;
        }

        public static IEnumerable<ICompany> ToModel(IEnumerable<Domain.Company> companies)
        {
            return companies.Select(x => new CompanyModel()
            {
                Id = x.Id,
                Address = x.Address,
                CreatorAccountId = x.CreatorAccountId,
                Emails = x.Emails,
                Name = x.Name,
                PhoneNumbers = x.PhoneNumbers,
                RecordInsertDate = x.RecordInsertDate,
                RecordLastEditDate = x.RecordLastEditDate,
                RecordStatus = x.RecordStatus,
                Url = x.Url
            });
        }
    }
}
