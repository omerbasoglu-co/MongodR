using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MongodR.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public IMongoCollection<T> Collection;

        public Repository(IMongoDatabase db)
        {
            Collection = db.GetCollection<T>(typeof(T).Name.ToLower());
        }

        public Repository(IMongoDatabase db, string tableName)
        {
            Collection = db.GetCollection<T>(tableName);
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
