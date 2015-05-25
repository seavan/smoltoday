using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace meridian.smolensk.proto
{
	public partial class regions : IValueListAspectProvider
	{
        public IValueListAspect GetValueListAspect(string _fieldName)
        {
            return new ValueListAspect<cities>(this,
                () => this.Cities, (a) =>
                    this.AddCities(new cities()
                    {
                        title = a
                    }, true), "Cities"
                );
        }
	}
}
