using System.IO;
namespace admin.db
{
    public interface  IUploadAttributeParser
    {
        void ParseObject(Stream _input, 
            string _contentType, 
            long _contentLength, 
            string _fileName,  
            string _targetFileName, 
            string _fieldName);

    }
}