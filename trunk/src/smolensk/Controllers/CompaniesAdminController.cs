using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Mvc;
using meridian.smolensk.controller;
using meridian.smolensk.system;
using yandex.services.Maps;

namespace smolensk.Controllers
{
    public class CompaniesAdminController : meridian_companies
    {
        private string key = "AG_GV1IBAAAAI7CNVgIAanGCcrGQC9h4tj1-F5JAIdQSSE8AAAAAAAAAAADSyaBzo4CRGPVSbykgemXg4FgBug==";
        public string GetCoordinates(string address)
        {
            var api = new Api(key);
            var point = api.GetCoordinatesString(api.NormalizeAddress(address, "Смоленск"));
            return point;
        }

        public override void Prepare(meridian.smolensk.proto.companies i)
        {
            base.Prepare(i);

            if (!string.IsNullOrEmpty(i.address))
            {
                var coords = GetCoordinates(i.address);

                if (!string.IsNullOrEmpty(coords))
                {
                    i.coordinates = coords;
                }

            }
        }

        public string RebindGeoCompanies()
        {
            Response.ContentType = "text/plain";
            var result = new StringBuilder();
            
            var toParse = GetAll().Where(s => !string.IsNullOrEmpty(s.address.Trim())).ToArray();
            
            foreach (var i in toParse)
            {
                var coords = GetCoordinates(i.address);

                if (!string.IsNullOrEmpty(coords))
                {
                    result.AppendFormat("{0}:{1}\r\n", i.address, coords);
                    i.coordinates = coords;
                    this.Service.Update(i);
                }
                else
                {
                    result.AppendFormat("{0}:{1}\r\n", i.address, "not found");
                }
            }

            return result.ToString();
            //return Redirect("/CompaniesAdmin");
        }
    }
}