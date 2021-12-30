using System;
using System.Threading;
using System.Threading.Tasks;
using AppStatus.Api.Framework;
using AppStatus.Api.Framework.Constants;
using AppStatus.Api.Framework.Services.Object;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace AppStatus.Api.Service.Object
{
    public class ObjectService : IObjectService
    {
        private readonly IMongoCollection<Domain.Object> _objectCollection;

        public ObjectService(IOptionsMonitor<ApplicationOptions> options)
        {
            var mongoClient = new MongoClient(
            options.CurrentValue.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                options.CurrentValue.DatabaseName);

            _objectCollection = mongoDatabase.GetCollection<Domain.Object>("Object");
        }

        public async Task<string> CreateAsync(string accountId, byte[] content, string hash, CancellationToken cancellationToken)
        {
            var @object = await _objectCollection.Find(x => x.Hash == hash).FirstOrDefaultAsync(cancellationToken);
            if (@object != null)
                return @object.Id;

            var newObject = new Domain.Object()
            {
                RecordInsertDate = DateTime.Now,
                RecordLastEditDate = DateTime.Now,
                RecordStatus = RecordStatus.Inserted,
                Content = content,
                CreatorAccountId = accountId,
                Hash = hash
            };

            await _objectCollection.InsertOneAsync(newObject, new InsertOneOptions(), cancellationToken);

            return newObject.Id;
        }
    }
}
