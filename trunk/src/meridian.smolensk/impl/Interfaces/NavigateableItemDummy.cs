namespace meridian.smolensk.proto
{
    public class NavigateableItemDummy : INavigateableItem
    {
        public NavigateableItemDummy(string uri, string title)
        {
            m_Uri = uri;
            m_Title = title;
        }

        private string m_Uri;
        private string m_Title;

        public string GetUri()
        {
            return m_Uri;
        }

        public string GetHrefTitle()
        {
            return m_Title;
        }
    }
}