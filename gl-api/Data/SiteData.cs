namespace gl_api.Data
{
    public interface ISiteData
    {
        List<Site> GetSites();
    }

    // Placeholder for site repo
    public class SiteData : ISiteData
    {
        public List<Site> GetSites()
        {
            var sites = new List<Site>();

            sites.Add(
                new Site("Cleveland")
                {
                    Id = 1,
                    Altitude = 2400,
                    SeismicZone = 0
                }
            );
            sites.Add(
                new Site("Sacramento")
                {
                    Id = 2,
                    Altitude = 10,
                    SeismicZone = 2
                }
            );
            sites.Add(
                new Site("San Andreas")
                {
                    Id = 3,
                    Altitude = 223,
                    SeismicZone = 4
                }
            );

            return sites;
        }
    }
}
