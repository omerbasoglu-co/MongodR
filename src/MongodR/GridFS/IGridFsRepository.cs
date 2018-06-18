using MongoDB.Bson;
using MongoDB.Driver.GridFS;

namespace MongodR.GridFS
{
    public interface IGridFsRepository
    {
        GridFSBucket GridFsBucket { get; }
        ObjectId UploadFile(string filePath);
        GridFSFileInfo GetFileById(ObjectId objectId);
        byte[] GetFileBytesById(ObjectId objectId);
    }
}
