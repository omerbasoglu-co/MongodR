using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MongodR.Repository
{
    public interface IRepository<T> where T : class
    {
        IMongoCollection<T> Collection { get; }
        T FindById(ObjectId objectId);
        IList<T> Find(FilterDefinition<T> filter);
        IList<T> Find(FilterDefinition<T> filter, int? skip, int? limit);
        double Count(FilterDefinition<T> filter);
    }
}
