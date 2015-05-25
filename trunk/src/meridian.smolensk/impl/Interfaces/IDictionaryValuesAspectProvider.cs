using admin.db;

namespace meridian.smolensk.proto
{
    public interface ILookupValueAspectProvider
    {
        ILookupValueAspect GetLookupValueAspect(string _fieldName);
    }
    public interface IDictionaryValuesAspectProvider
    {
        IDictionaryValuesAspect GetDictionaryValuesAspect(string _fieldName);
    }

    public interface IAttachedPhotoAspectProvider : IDatabaseEntity
    {
        IAttachedPhotoAspect GetAttachedPhotoAspect(string _fieldName);
    }

    public interface IOneToManyAspectProvider
    {
        IOneToManyAspect GetOneToManyAspect(string _fieldName);
    }

    public interface IScheduleAspectProvider
    {
        IScheduleAspect GetScheduleAspect(string _fieldName);
    }
}