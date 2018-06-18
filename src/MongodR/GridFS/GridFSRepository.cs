using MongodR.Uow;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using MongoDB.Bson;

using System.IO;

namespace MongodR.GridFS
{
    public class GridFsRepository : IGridFsRepository
    {
        public GridFSBucket GridFsBucket { get; }

        public GridFsRepository(IUnitOfWork unitOfWork)
        {
            GridFsBucket = new GridFSBucket(unitOfWork.Database);
        }

        public ObjectId UploadFile(string filePath)
        {
            using (var s = File.OpenRead(filePath))
            {
                return GridFsBucket.UploadFromStreamAsync(Path.GetFileName(filePath), s).Result;
            }
        }

        public GridFSFileInfo GetFileById(ObjectId objectId)
        {
            var filter = Builders<GridFSFileInfo>.Filter.Eq("_id", objectId);

            var findOptions = new GridFSFindOptions
            {
                Limit = 1
            };

            return GridFsBucket.Find(filter, findOptions).FirstOrDefault();
        }

        public byte[] GetFileBytesById(ObjectId objectId)
        {
            return GridFsBucket.DownloadAsBytes(objectId);
        }
    }
}
