namespace gl_api
{
    public class Site
    {
        public int? Id {get;set;}
        public string Name { get; set; }

        public Site(string name)
        {
            Name = name;
        }

        public string? GeoLocation { get; set; }

        public int? Altitude  { get; set; }

        public int? SeismicZone { get; set; }

        
    }
}