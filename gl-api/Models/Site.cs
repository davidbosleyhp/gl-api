namespace gl_api
{
    /* Represents a single site */
    public class Site
    {
        public int? Id {get;set;}
        public string Name { get; set; }

        public Site(string name)
        {
            Name = name;
        }

        // What format should GeoLocation be?
        public string? GeoLocation { get; set; }

        public int? Altitude  { get; set; }

        public int? SeismicZone { get; set; }

        
    }
}