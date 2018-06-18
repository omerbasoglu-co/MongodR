using MongoDB.Driver;

namespace MongodR.Uow
{
    public class UnitOfWork : IUnitOfWork
    {
        public IMongoDatabase Database { get; }

        public UnitOfWork(MongoClientSettings mongoClientSettings, string databaseName, MongoDatabaseSettings mongoDatabaseSettings=null)
        {
            var client = new MongoClient(mongoClientSettings);
            if (mongoDatabaseSettings != null)
                Database = client.GetDatabase(databaseName, mongoDatabaseSettings);

            Database = client.GetDatabase(databaseName);
        }

        public UnitOfWork(MongoUrl mongoUrl, string databaseName, MongoDatabaseSettings mongoDatabaseSettings = null)
        {
            var client = new MongoClient(mongoUrl);
            if (mongoDatabaseSettings != null)
                Database = client.GetDatabase(databaseName, mongoDatabaseSettings);

            Database = client.GetDatabase(databaseName);
        }

        public UnitOfWork(string connectionString, string databaseName, MongoDatabaseSettings mongoDatabaseSettings = null)
        {
            var client = new MongoClient(connectionString);
            if (mongoDatabaseSettings != null)
                Database = client.GetDatabase(databaseName, mongoDatabaseSettings);

            Database = client.GetDatabase(databaseName);
        }
    }
}
