using MongoDB.Driver;

namespace MongodR.Uow
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IMongoDatabase _database;
        
        public UnitOfWork(MongoClientSettings mongoClientSettings, string databaseName, MongoDatabaseSettings mongoDatabaseSettings=null)
        {
            var client = new MongoClient(mongoClientSettings);
            if (mongoDatabaseSettings != null)
                _database = client.GetDatabase(databaseName, mongoDatabaseSettings);

            _database = client.GetDatabase(databaseName);
        }

        public UnitOfWork(MongoUrl mongoUrl, string databaseName, MongoDatabaseSettings mongoDatabaseSettings = null)
        {
            var client = new MongoClient(mongoUrl);
            if (mongoDatabaseSettings != null)
                _database = client.GetDatabase(databaseName, mongoDatabaseSettings);

            _database = client.GetDatabase(databaseName);
        }

        public UnitOfWork(string connectionString, string databaseName, MongoDatabaseSettings mongoDatabaseSettings = null)
        {
            var client = new MongoClient(connectionString);
            if (mongoDatabaseSettings != null)
                _database = client.GetDatabase(databaseName, mongoDatabaseSettings);

            _database = client.GetDatabase(databaseName);

        }
    }
}
