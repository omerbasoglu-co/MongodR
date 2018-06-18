using MongoDB.Driver;

namespace MongodR.Uow
{
    public interface IUnitOfWork
    {
        IMongoDatabase Database { get; }
    }
}
