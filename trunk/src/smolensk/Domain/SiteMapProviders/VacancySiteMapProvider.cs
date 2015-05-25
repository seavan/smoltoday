using System.Collections.Generic;
using System.Linq;
using MvcSiteMapProvider;
using meridian.smolensk.system;

namespace smolensk.Domain.SiteMapProviders
{
    public class VacancySiteMapProvider : CachedSiteMapProvider
    {
        public override IEnumerable<DynamicNode> DoGet(ISiteMapNode node)
        {
            var meridian = Meridian.Default;
            var nodes = new List<DynamicNode>();

            var companies = meridian.companiesStore.All().Where(s => !string.IsNullOrEmpty(s.title)).ToArray();

            foreach (var company in companies)
            {
                var companyNode = new DynamicNode
                {
                    Key = "vacancy_companies_" + company.id,
                    Action = "Company",
                    Controller = "Vacancy",
                    Title = company.title,
                    PreservedRouteParameters = new List<string> { "entryName" }
                };

                companyNode.RouteValues.Add("id", company.id);
                nodes.Add(companyNode);

                var vacancies = meridian.vacanciesStore.All().Where(item => item.company_id == company.id);
                
                foreach (var vacancy in vacancies)
                {
                    var vacancyNode = new DynamicNode
                    {
                        Key = "vacancy_vacancies_" + vacancy.id,
                        Action = "Vacancy",
                        ParentKey = companyNode.Key,
                        Controller = "Vacancy",
                        Title = vacancy.title,
                        PreservedRouteParameters = new List<string> { "entryName" }
                    };

                    vacancyNode.RouteValues.Add("id", vacancy.id);
                    nodes.Add(vacancyNode);
                }
            }

            var resumes = meridian.resumesStore.All();
            
            foreach (var resume in resumes)
            {
                string name = string.Format("{0} {1} {2}",
                                            string.IsNullOrEmpty(resume.last_name) ? string.Empty : resume.last_name,
                                            string.IsNullOrEmpty(resume.first_name) ? string.Empty : resume.first_name,
                                            string.IsNullOrEmpty(resume.middle_name) ? string.Empty : resume.middle_name
                
                    );

                var resumeNode = new DynamicNode
                    {
                        Key = "vacancy_resumes_" + resume.id,
                        Action = "Resume",
                        Controller = "Vacancy",
                        Title = string.Format("Резюме пользователя {0}", name),
                        PreservedRouteParameters = new List<string> { "entryName" }
                    };

                resumeNode.RouteValues.Add("id", resume.id);
                nodes.Add(resumeNode);
            }

            return nodes;
        }
    }
}