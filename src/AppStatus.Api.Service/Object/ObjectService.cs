using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AppStatus.Api.Framework;
using AppStatus.Api.Framework.Constants;
using AppStatus.Api.Framework.Exceptions;
using AppStatus.Api.Framework.Services.Object;
using AppStatus.Api.Service.Object.Models;
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

        public async Task<IObject> GetByIdAsync(string accountId, string id, CancellationToken cancellationToken)
        {
            var @object = await _objectCollection.Find(x => x.CreatorAccountId == accountId && x.Id == id).FirstOrDefaultAsync(cancellationToken);
            if (@object == null)
                throw new ValidationException("100", "Object not found.");

            return ToModel(new[] { @object }).First();
        }

        public async Task<string> CreateAsync(string accountId, byte[] content, string contentType, string hash, CancellationToken cancellationToken)
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
                Hash = hash,
                ContentType = contentType
            };

            await _objectCollection.InsertOneAsync(newObject, new InsertOneOptions(), cancellationToken);

            return newObject.Id;
        }

        public IEnumerable<IObject> ToModel(IEnumerable<Domain.Object> objects)
        {
            return objects.Select(x => new ObjectModel()
            {
                RecordStatus = x.RecordStatus,
                Content = x.Content,
                ContentType = x.ContentType,
                CreatorAccountId = x.CreatorAccountId,
                Hash = x.Hash,
                Id = x.Id,
                RecordInsertDate = x.RecordInsertDate,
                RecordLastEditDate = x.RecordLastEditDate
            });
        }
    }
}
