namespace gl_api.Data
{
    public interface ISiteData
    {
        Site AddSite(Site site);
        void DeleteSite(int id);
        Site? GetSite(int id);
        List<Site> GetSites();
        void UpdateSite(Site site);
    }

    // Placeholder for site repo
    public class SiteData : ISiteData
    {
        static List<Site> _sites = new List<Site>();

        private int _nextId = 4;

        static SiteData()
        {
             _sites.Add(
                new Site("Cleveland")
                {
                    Id = 1,
                    Altitude = 2400,
                    SeismicZone = 0
                }
            );
            _sites.Add(
                new Site("Sacramento")
                {
                    Id = 2,
                    Altitude = 10,
                    SeismicZone = 2
                }
            );
            _sites.Add(
                new Site("San Andreas")
                {
                    Id = 3,
                    Altitude = 223,
                    SeismicZone = 4
                }
            );

        }

        public Site AddSite(Site site)
        {
            site.Id = _nextId;
            _nextId++;  
            _sites.Add(site);          
            return site;
        }

        public void DeleteSite(int id)
        {
             var currentSite = _sites.FirstOrDefault(x=>x.Id == id);

            if (currentSite != null)
            {
                _sites.Remove(currentSite);
            }
        }

        public Site? GetSite(int id)
        {

            return _sites.FirstOrDefault(x=>x.Id == id);
        }

        public List<Site> GetSites()
        {            

            return _sites;
        }

        public void UpdateSite(Site site)
        {
            var currentSite = _sites.FirstOrDefault(x=>x.Id == site.Id);

            if (currentSite != null)
            {
                _sites.Remove(currentSite);
                _sites.Add(site);
            }
        }
    }
}
