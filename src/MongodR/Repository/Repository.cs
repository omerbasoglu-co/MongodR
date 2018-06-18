using System;
using System.Collections.Generic;
using MongodR.Uow;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MongodR.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public IMongoCollection<T> Collection;

        public Repository(IUnitOfWork unitOfWork)
        {
            string collectionName = typeof(T).Name.ToLower();

            if (string.IsNullOrEmpty(collectionName))
                throw new ArgumentException("Collection name cannot be empty for this entity");

            Collection = unitOfWork.Database.GetCollection<T>(collectionName);
        }

        public Repository(IUnitOfWork unitOfWork, string collectionName)
        {
            if (string.IsNullOrEmpty(collectionName))
                throw new ArgumentException("Collection name cannot be empty for this entity");

            Collection = unitOfWork.Database.GetCollection<T>(collectionName);
        }

        public T FindById(ObjectId objectId)
        {
            var filter = new FilterDefinitionBuilder<T>().Eq("_id", objectId);
            return Collection.Find(filter).FirstOrDefault();
        }

        public IList<T> Find(FilterDefinition<T> filter)
        {
            return Collection.Find(filter).ToList();
        }

        public IList<T> Find(FilterDefinition<T> filter, int? skip, int? limit)
        {
            return Collection.Find(filter).Skip(skip).Limit(limit).ToList();
        }

        public double Count(FilterDefinition<T> filter)
        {
            return Collection.Count(filter);
        }
    }
}
