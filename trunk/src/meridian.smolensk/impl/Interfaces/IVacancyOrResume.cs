using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using meridian.smolensk.proto;

namespace meridian.smolensk.impl.Interfaces
{
    public interface IVacancyOrResume
    {
        List<vacancy_facilities> GetFacilityList();
        vacancy_facility_variants GetVariant(long facilityId);
        int Weight { get; set; }
        IEnumerable<vacancy_professionals> GetRootProfessionals();
    }
}
