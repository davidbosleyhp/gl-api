using Microsoft.AspNetCore.Mvc;
using gl_api.Data;

namespace gl_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
        public IEnumerable<Site> Get()
        {
            return _siteData.GetSites()
            .ToArray();
        }
    }
}