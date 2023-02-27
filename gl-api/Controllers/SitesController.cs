using Microsoft.AspNetCore.Mvc;
using gl_api.Data;

namespace gl_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SitesController : ControllerBase
    {
        private readonly ILogger<SitesController> _logger;
        private readonly ISiteData _siteData;

        public SitesController(ILogger<SitesController> logger, ISiteData siteData)
        {
            _logger = logger;
            _siteData = siteData;
        }

        [HttpGet(Name = "GetSites")]
        public async Task<ActionResult<IEnumerable<Site>>> Get()
        {
            // will eventually await repo call

            var sites = _siteData.GetSites().ToArray();
            _logger.LogInformation($"GetSites returning {sites.Length} sites");
            return sites;
        }

        [HttpGet("{id}", Name ="GetSiteById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Site>> Get(int id)
        {
            // will eventually await repo call

            var site = _siteData.GetSite(id);

            if (site == null)
                return NotFound();

            _logger.LogInformation($"GetSite returning {site.Name} site");
            return site;
        }

        /// <summary>
        /// Creates a net site
        /// </summary>
        /// <returns>A newly created site</returns> 
        /// <remarks>
        /// Sample request: blah
        /// </remarks>
        /// <response code="201">Returns the newly created site</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Site>> AddSite([FromBody]Site site) 
        {
            if (!IsValidSite(site))
                return BadRequest();

            _siteData.AddSite(site);

            return CreatedAtRoute("GetSiteById", new {id = site.Id}, site);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateSite(int id,[FromBody]Site site) 
        {
            if (!IsValidSite(site))
                return BadRequest();

            var originalSite = _siteData.GetSite(id);
            if (originalSite == null)
                return NotFound();

            originalSite.Name = site.Name;
            originalSite.Altitude = site.Altitude;
            originalSite.GeoLocation = site.GeoLocation;
            originalSite.SeismicZone = site.SeismicZone;
            _siteData.UpdateSite(originalSite);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteSite(int id) 
        {          
            var originalSite = _siteData.GetSite(id);
            if (originalSite == null)
                return NotFound();

            _siteData.DeleteSite(id);

            return NoContent();
        }




        private bool IsValidSite(Site site)
        {
            return !string.IsNullOrWhiteSpace(site.Name?.Trim());
        }
    }
}
