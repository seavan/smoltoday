using System.Linq;

namespace smolensk.Models
{

    public class MenuItem
    {
        public string title { get; set; }
        public string route { get; set; }
    }

    public static class MainMenu
    {
        static MainMenu()
        {
            
        }

        public static MenuItem GetCurrentMenuItem(string _pathAndQuery)
        {
            return m_Menu.AsEnumerable().FirstOrDefault(s => _pathAndQuery.StartsWith(s.route));
        }

        public static MenuItem[] MenuItems
        {
            get
            {
                return m_Menu;
            }
            
        }

        private static MenuItem[] m_Menu = new[]
                   {
                   new MenuItem()  { title = "Трансляции", route = "/translations" },
                   new MenuItem()  { title = "Видеоотчеты", route = "/summary" },
                   new MenuItem()  { title = "Интервью", route = "/interview" },
                   new MenuItem()  { title = "Болельщики", route = "/fans" },
                   new MenuItem()  { title = "Молодежь", route = "/youth" },
                   new MenuItem()  { title = "Студия", route = "/studio" },
                   //new MenuItem()  { title = "Клипы", route = "/clips" },
                   new MenuItem()  { title = "Эксклюзив", route = "/vip" },
                   new MenuItem()  { title = "История", route = "/history" },
                   
                   };


    }

    public class PlayerSetup
    {
        public PlayerSetup()
        {
            Logo = "http://fcdynamo.etcetera.ws/img/logo2.png";            
        }
        public PlayerProvider Provider { get; set;  }
        public string Streamer { get; set; }
        public string File { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Thumb { get; set;  }
        public string Logo { get; set; }
        public bool WideScreen { get; set; }
        public string IOSStreamer { get; set; }
    }
}