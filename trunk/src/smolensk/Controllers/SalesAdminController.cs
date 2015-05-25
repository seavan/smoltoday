using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using meridian.smolensk.controller;
using meridian.smolensk.proto;
using meridian.smolensk.system;

namespace smolensk.Controllers
{
    /// <summary>
    /// Reads a data source line by line. The source can be a file, a stream,
    /// or a text reader. In any case, the source is only opened when the
    /// enumerator is fetched, and is closed when the iterator is disposed.
    /// </summary>
    public sealed class LineReader : IEnumerable<string>
    {
        /// <summary>
        /// Means of creating a TextReader to read from.
        /// </summary>
        readonly Func<TextReader> dataSource;

        /// <summary>
        /// Creates a LineReader from a stream source. The delegate is only
        /// called when the enumerator is fetched. UTF-8 is used to decode
        /// the stream into text.
        /// </summary>
        /// <param name="streamSource">Data source</param>
        public LineReader(Func<Stream> streamSource)
            : this(streamSource, Encoding.UTF8)
        {
        }

        /// <summary>
        /// Creates a LineReader from a stream source. The delegate is only
        /// called when the enumerator is fetched.
        /// </summary>
        /// <param name="streamSource">Data source</param>
        /// <param name="encoding">Encoding to use to decode the stream
        /// into text</param>
        public LineReader(Func<Stream> streamSource, Encoding encoding)
            : this(() => new StreamReader(streamSource(), encoding))
        {
        }

        /// <summary>
        /// Creates a LineReader from a filename. The file is only opened
        /// (or even checked for existence) when the enumerator is fetched.
        /// UTF8 is used to decode the file into text.
        /// </summary>
        /// <param name="filename">File to read from</param>
        public LineReader(string filename)
            : this(filename, Encoding.UTF8)
        {
        }

        /// <summary>
        /// Creates a LineReader from a filename. The file is only opened
        /// (or even checked for existence) when the enumerator is fetched.
        /// </summary>
        /// <param name="filename">File to read from</param>
        /// <param name="encoding">Encoding to use to decode the file
        /// into text</param>
        public LineReader(string filename, Encoding encoding)
            : this(() => new StreamReader(filename, encoding))
        {
        }

        /// <summary>
        /// Creates a LineReader from a TextReader source. The delegate
        /// is only called when the enumerator is fetched
        /// </summary>
        /// <param name="dataSource">Data source</param>
        public LineReader(Func<TextReader> dataSource)
        {
            this.dataSource = dataSource;
        }

        /// <summary>
        /// Enumerates the data source line by line.
        /// </summary>
        public IEnumerator<string> GetEnumerator()
        {
            using (TextReader reader = dataSource())
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    yield return line;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class SalesAdminController : meridian_sales
    {
        public SalesAdminController()
        {
            //DefaultUploadVirtualFolder = Constants.RestaurantsDataFolder;
        }

        public class CompanyImport 
        {
            public string Section { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string Phone { get; set; }
            public string Address { get; set; }
            public string Hours { get; set; }
            public string Discount { get; set; }
            public string VacancyName { get; set; }
            public string Url { get; set; }
            public string Email { get; set; }
            public string SubSection { get; set; }
            public long Salary { get; set; }
            public string Position { get; set; }
        }



        public ActionResult ImportVacancies(string text = "", int add = 0)
        {
            if (!string.IsNullOrEmpty(text))
            {
                var reader = new LineReader(() => new StringReader(text));
                var result = new List<CompanyImport>();
                foreach (var l in reader)
                {

                    var cells = l.Split('\t').Select(s => s.Trim()).ToArray();
                    var company = new CompanyImport()
                    {
                        Position = cells[0],
                        Salary = int.Parse(cells[1].Replace(" ", "")),
                        Description = cells[2],
                        Name = cells[4],
                        Section = cells[6]
                    };

                    result.Add(company);

                }

                if (add > 0)
                {
                    var categories = Meridian.Default.company_categoriesStore;
                    var companies = Meridian.Default.companiesStore;

                    foreach (var i in result)
                    {
                        var existing = companies.All().FirstOrDefault(s => s.title == i.Name);

                        if (existing == null)
                        {
                            existing = companies.CreateItem();
                            existing = companies.Insert(existing);
                        }

                        var section = categories.All().FirstOrDefault(s => s.title.ToLower() == i.Section.ToLower());

                        if (section == null)
                        {
                            section = new company_categories()
                            {
                                name = i.Section
                            };

                            section = categories.Insert(section);
                            section = categories.Insert(new company_categories()
                            {
                                   parent = section.id,
                                   name = "Все"
                            });
                        }

                        existing.category_id = section.id;


                        existing.title = i.Name;
                        existing.publish_date = DateTime.Now;

                        companies.Update(existing);

                        var vacancies = Meridian.Default.vacanciesStore;

                        var existingVacancy = vacancies.All().FirstOrDefault(s => s.company_id == existing.id && i.VacancyName == s.title);

                        if (existingVacancy == null)
                        {
                            existingVacancy = vacancies.CreateItem();
                            existingVacancy.company_id = existing.id;
                            existingVacancy.title = i.Position;
                            existingVacancy = vacancies.Insert(existingVacancy);
                        }

                        existingVacancy.is_publish = true;
                        existingVacancy.city_id = 1;
                        existingVacancy.work_city_id = 1;
                        existingVacancy.work_region_id = 1;
                        existingVacancy.description = i.Description;

                        existingVacancy.compensation1 = (int) i.Salary;

                        vacancies.Update(existingVacancy);

                    }

                   
                }

                return View("Import", result);
            }

            return View("Import");
        }


        public ActionResult ImportCompanies(string text = "", int add = 0)
        {
            if (!string.IsNullOrEmpty(text))
            {
                var reader = new LineReader(() => new StringReader(text));
                var result = new List<CompanyImport>();
                foreach (var l in reader)
                {
                    
                    var cells = l.Split('\t').Select(s => s.Trim()).ToArray();
                    var company = new CompanyImport()
                        {
                            Name = cells[0],
                            Description = cells[1],
                            Address = cells[2],
                            Phone = cells[3],
                            Url = cells[4],
                            Email = cells[5],
                            Section = cells[6],
                            SubSection = cells[7]
                        };
                    result.Add(company);
                    
                }

                if (add > 0)
                {
                    var categories = Meridian.Default.company_categoriesStore;
                    var companies = Meridian.Default.companiesStore;

                    foreach (var i in result)
                    {
                        var existing = companies.All().FirstOrDefault(s => s.title == i.Name);

                        if (existing == null)
                        {
                            existing = companies.CreateItem();
                            existing = companies.Insert(existing);
                        }

                        var section = categories.All().FirstOrDefault(s => s.title.ToLower() == i.Section.ToLower());

                        if (section == null)
                        {
                            section = new company_categories()
                                {
                                    name = i.Section
                                };

                            section = categories.Insert(section);
                        }

                        existing.category_id = section.id;

                        if (!String.IsNullOrEmpty(i.SubSection))
                        {
                            var subSection =
                                categories.All()
                                          .FirstOrDefault(
                                              s => s.parent == section.id && s.title.ToLower() == i.SubSection.ToLower());

                            if (subSection == null)
                            {
                                subSection = new company_categories()
                                    {
                                        parent = section.id,
                                        name = i.SubSection
                                    };

                                subSection = categories.Insert(subSection);
                            }

                            existing.category_id = subSection.id;
                        }

                        existing.publish_date = DateTime.Now;
                        existing.title = i.Name;
                        existing.description = i.Description;
                        existing.phones = i.Phone;
                        existing.address = i.Address;
                        existing.www = i.Url;
                        existing.email = i.Email;

                        companies.Update(existing);
                    }

                }

                return View("Import", result);
            }

            return View("Import");
        }

        public ActionResult Import(string text = "", int add = 0)
        {
            if (!string.IsNullOrEmpty(text))
            {
                var reader = new LineReader(() => new StringReader(text));

                string section = "";
                string company = "";
                var currentCompany = new CompanyImport();
                var result = new List<CompanyImport>();

                foreach (var l in reader)
                {
                    var line = l.Trim();
                    if (line.Contains("<a"))
                    {
                        var match = Regex.Match(line, "<a.*?>(.*?)</a>");
                        section = match.Groups[1].Value;
                        continue;
                    }

                    if ((string.IsNullOrEmpty(section) || string.IsNullOrEmpty(company)) && string.IsNullOrEmpty(line))
                    {
                        continue;
                    }

                    if (!string.IsNullOrEmpty(section) && string.IsNullOrEmpty(company))
                    {
                        company = line;
                        currentCompany.Name = company;
                        continue;
                    }


                    if ((!string.IsNullOrEmpty(section) || !string.IsNullOrEmpty(company)) && string.IsNullOrEmpty(line))
                    {
                        currentCompany.Section = section;
                        result.Add(currentCompany);
                        company = null;
                        currentCompany = new CompanyImport();
                        continue;
                    }

                    if ((!string.IsNullOrEmpty(section) || !string.IsNullOrEmpty(company)) && !string.IsNullOrEmpty(line))
                    {
                        

                        if (line.StartsWith("с "))
                        {
                            currentCompany.Hours = line;
                        }
                        else
                        if (line.StartsWith("без"))
                        {
                            if (!String.IsNullOrEmpty(currentCompany.Hours))
                            {
                                currentCompany.Hours += ", " + line;    
                            }
                            else
                            {
                                currentCompany.Hours = line;    
                            }
                            
                        }
                        else if(line.StartsWith("тел."))
                        {
                            if (String.IsNullOrEmpty(currentCompany.Phone))
                            {
                                currentCompany.Phone = line.Replace("тел.", "").Replace(":", "");
                            }
                            else
                            {
                                currentCompany.Phone += ", " + line.Replace("тел.", "");
                            }
                        }
                        else if (line.Contains("г.") || line.Contains("ул.") || line.Contains("д."))
                        {
                            currentCompany.Address = line;
                        }
                        else if (line.Contains("скидка"))
                        {
                            currentCompany.Discount = line.Replace("скидка", "").Trim();
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(currentCompany.Description))
                            {
                                currentCompany.Description = line;
                            }
                            else
                            {
                                currentCompany.Description += ". " + line;
                            }
                        }



                    }




                }

                if (add > 0)
                {
                    var companies = Meridian.Default.companiesStore;
                    var sales = Meridian.Default.salesStore;
                    var category = Meridian.Default.company_categoriesStore.All().FirstOrDefault(s => s.name.StartsWith("Услуги"));

                    //result = result.Where(s => !String.IsNullOrEmpty(s.Discount)).ToArray();

                    foreach (var c in result)
                    {
                        var saleCategory = Meridian.Default.sale_categoriesStore.All().FirstOrDefault(s => s.title.Equals(c.Section));

                        if (saleCategory == null)
                        {
                            saleCategory = new sale_categories()
                                {
                                    title = c.Section
                                };
                            Meridian.Default.sale_categoriesStore.Insert(saleCategory);

                        }

                        var newCompany = companies.All().FirstOrDefault(s => s.title.Equals(c.Name));

                        if (newCompany == null)
                        {
                            newCompany = new companies();
                            companies.Insert(newCompany);
                        }
                        

                        newCompany.publish_date = DateTime.Now;
                        newCompany.title = c.Name;
                        newCompany.description = c.Description;
                        newCompany.map_title = c.Name;
                        newCompany.map_description = c.Description;
                        newCompany.work_time = c.Hours;
                        newCompany.phones = c.Phone;
                        newCompany.address = c.Address;

                        if (category != null)
                        {
                            newCompany.category_id = category.id;
                        }

                        companies.Update(newCompany);

                        if (!String.IsNullOrEmpty(c.Discount))
                        {
                            var existingSales = sales.All().Where(s => s.company_id.Equals(newCompany.id)).ToArray();

                            foreach (var es in existingSales)
                            {
                                sales.Delete(es);
                            }

                            var discount = c.Discount.Replace("%", "");
                            var defDisc = 5;
                            if (int.TryParse(discount, out defDisc))
                            {

                            }

                            var sale = new sales()
                                {
                                    title = c.Name,
                                    start_date = DateTime.Now,
                                    end_date = DateTime.Now.AddYears(1),
                                    company_id = newCompany.id,
                                    text = c.Description,
                                    percent = defDisc,
                                    percent_max = defDisc,
                                    phone = c.Phone,
                                    work_time = c.Hours,
                                    category_id = saleCategory.id,
                                    sale_type_id = 1
                                };

                            sales.Insert(sale);
                        }
                    }

                    
                }

                return View(result);

            }

            return View();
        }
   
    }
}