namespace gl_apiTests;
using gl_api;
using gl_api.Controllers;
using gl_api.Data;
using Microsoft.Extensions.Logging;

public class SiteControllerTests
{
    [Fact]
    public async Task When_Called_Expect_ReturnsCorrectSites()
    {
        var repoMock = new Mock<ISiteData>();
        var logMock = new Mock<ILogger<SitesController>>();

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

        repoMock.Setup(r => r.GetSites()).Returns(sites); //Task.FromResult(sites));

        var controller = new SitesController(logMock.Object, repoMock.Object);

        var result = await controller.Get();
        Assert.NotNull(result.Value);
        Assert.Equal(sites, result.Value);
    }
}
