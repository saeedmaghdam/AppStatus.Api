using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AppStatus.Api.Framework;
using AppStatus.Api.Framework.Constants;
using AppStatus.Api.Framework.Exceptions;
using AppStatus.Api.Framework.Services.Employee;
using AppStatus.Api.Service.Employee.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace AppStatus.Api.Service.Employee
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IMongoCollection<Domain.Employee> _employeeCollection;
        private readonly IMongoCollection<Domain.Account> _accountCollection;

        public EmployeeService(IOptionsMonitor<ApplicationOptions> options)
        {
            var mongoClient = new MongoClient(
            options.CurrentValue.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                options.CurrentValue.DatabaseName);

            _employeeCollection = mongoDatabase.GetCollection<Domain.Employee>("Employee");
            _accountCollection = mongoDatabase.GetCollection<Domain.Account>("Account");
        }

        public async Task<IEnumerable<IEmployee>> GetByCompanyIdAsync(string accountId, string companyId, CancellationToken cancellationToken)
        {
            var account = await _accountCollection.Find(x => x.Id == accountId).FirstOrDefaultAsync(cancellationToken);
            if (account == null)
                throw new ValidationException("100", "Account not found.");

            var result = await _employeeCollection.Find(x => x.CreatorAccountId == accountId && x.CompanyId == companyId && x.RecordStatus != RecordStatus.Deleted).ToListAsync(cancellationToken);

            return ToModel(result);
        }

        public static IEnumerable<IEmployee> ToModel(IEnumerable<Domain.Employee> employees)
        {
            return employees.Select(x => new EmployeeModel()
            {
                CreatorAccountId = x.CreatorAccountId,
                Email = x.Email,
                Id = x.Id,
                Name = x.Name,
                PhoneNumber = x.PhoneNumber,
                PictureId = x.PictureId,
                ProfileUrl = x.ProfileUrl,
                RecordInsertDate = x.RecordInsertDate,
                RecordLastEditDate = x.RecordLastEditDate,
                RecordStatus = x.RecordStatus,
                Role = Role.ToString(x.RoleId),
                RoleId = x.RoleId
            });
        }
    }
}
