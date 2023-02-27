using gl_api;
using gl_api.Controllers;
using gl_api.Data;
using Microsoft.Extensions.Logging;

namespace gl_apiTests;

public class SiteControllerBase
{
    protected Mock<ISiteData> _repoMock;
    protected Mock<ILogger<SitesController>> _loggerMock;

    protected SitesController _controller;

    private int _nextId = 0;
    public SiteControllerBase()
    {
        _repoMock = new Mock<ISiteData>();
        _loggerMock  = new Mock<ILogger<SitesController>>();

        _controller = new SitesController(_loggerMock.Object, _repoMock.Object);
    }

    protected Site CreateSite()
    {
        _nextId++;
        return new Site("Europe" + _nextId)
            {                
                Altitude = 2400,
                SeismicZone = 0
            };

    }


    protected List<Site> CreateSites()
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