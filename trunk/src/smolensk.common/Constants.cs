using admin.web.common;
namespace smolensk.common
{
    public class Constants : CommonConstants
    {
        public const string YandexKey = "AG_GV1IBAAAAI7CNVgIAanGCcrGQC9h4tj1-F5JAIdQSSE8AAAAAAAAAAADSyaBzo4CRGPVSbykgemXg4FgBug==";
        /// <summary>
        /// Кол-во резюме отображаемых в блоке "Похожие резюме" на странице одного резюму
        /// </summary>
        public const int SimilarResumesCount = 5;
        
        /// <summary>
        /// Кол-во вакансий отображаемых в блоке "Похожие вакансии" на странице одной вакансии
        /// </summary>
        public const int SimilarVacanciesCount = 3;

        /// <summary>
        /// Ссылка на урл всех компаний в вакансиях. 
        /// NOTE: По какой-то неведомой мне причине этот урл на странице SearchCompanies 
        /// генерится со всеми параметрами и становится невозможным делать ссылки "На все компании"
        /// </summary>
        public const string VacancyCompaniesUrl = "/Vacancies/SearchCompany";
        /// <summary>
        /// Кол-во вакансий отображаемых в виджите популярные вакансии
        /// </summary>
        public const int CountOfPopularityVacancies = 5;
        /// <summary>
        /// Кол-во компаний отображаемых в виджете Работа в компаниях
        /// </summary>
        public const int CountOfWorkInCompanies = 10;
        /// <summary>
        /// Кол-во вакансии отображаемых в виджете Вакансии недели
        /// </summary>
        public const int CountOfWeekVacancies = 10;
        /// <summary>
        /// Кол-во компаний в категории отображаемых в виджете TopCompanies
        /// </summary>
        public const int TopCompanies = 5;
        /// <summary>
        /// Кол-во отзывов отображаемое в виджете "Свежие отзывы"
        /// </summary>
        public const int CountOfLastComments = 2;
        /// <summary>
        /// Кол-во подкатегорий выводимое на странице Companies/Categories под каждой
        /// рутовой категорией
        /// </summary>
        public const int TopSubCompanyCategory = 4;
        public const string AnyLetter = "!";
        
        /// <summary>
        /// PageSizes используются на страницах для вывода дропдауна "Выводить по"
        /// поэтому для корректной работы пейджинга лучше, чтобы PageSize = PageSizes[0]
        /// то есть при смене PageSize также лучше поменять PageSizes[0]
        /// </summary>
        public static readonly int[] PageSizes = {2, 6, 12, 24};

        public const int PageSize = 2;

        /// <summary>
        /// Число элементов в списках по умолчанию
        /// </summary>
        public const int DefaultListPageSize = 12;

        public const int PhotosPageSize = DefaultListPageSize;
        public const int ResumesPageSize = DefaultListPageSize;
        public const int VacanciesPageSize = DefaultListPageSize;
        public const int AdvertsPageSize = DefaultListPageSize;
        public const int RestaurantsPageSize = 6;
        public const int SalesPageSize = 9;
        public const int BlogsPageSize = 9;
        public const int NewsPageSize = 9;

        public const int SimilarRestaurantsMax = 5;

        public const string UserDataFolder = "/content/userdata/";
        public const string TempFolder = UserDataFolder + "temp/";
        public const string NewsDataFolder = UserDataFolder + "news/";
        public const string BlogsDataFolder = UserDataFolder + "blogs/";
        public const string ActionsDataFolder = UserDataFolder + "actions/";
        public const string RestaurantsDataFolder = UserDataFolder + "restaurants/";
        public const string CompaniesDataFolder = UserDataFolder + "companies/";
        public const string CompanyFilesDataFolder = CompaniesDataFolder + "files/";
        public const string CompanyCategoriesFolder = "/content/categories/";
        public const string AdvertsDataFolder = UserDataFolder + "adverts/";
        public const string AdvertsNoPhoto = AdvertsDataFolder + "emptyImage.gif";
        public const string AdvertsNoPhotoInList = AdvertsDataFolder + "emptyImageList.gif";
        public const string SalesDataFolder = UserDataFolder + "sales/";
        public const string AvatarsFolder = UserDataFolder + "avatars/";
        public const string VacanciesFolder = UserDataFolder + "vacancies/";
        public const string ResumeFolder = UserDataFolder + "resumes/";
        public const string PhotoFolder = UserDataFolder + "photobank/";


        
    }
}