namespace meridian.smolensk.proto
{
    public interface ILookupValue
    {
        long id { get; }
        string lookup_title { get; }
        /// <summary>
        /// for multi level value lists
        /// </summary>
        int lookup_value_level { get; }

        /// <summary>
        /// make level lists
        /// </summary>
        bool lookup_value_disabled { get; }
    }

   public class LookupValueDummy : ILookupValue
   {
       public long id { get; set; }

       public string lookup_title { get; set; }

       public int lookup_value_level { get; set; }

       public bool lookup_value_disabled { get; set; }
   }
}