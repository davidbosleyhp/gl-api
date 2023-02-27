namespace gl_apiTests;
using gl_api;
using gl_api.Controllers;
using gl_api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

public class SiteControllerGetByIdTests : SiteControllerBase
{
    [Fact]
    public async Task When_CalledWithExistingId_Expect_ReturnsCorrectSite()
    {
        var sites = CreateSites();

        var site = sites[1];

        _repoMock.Setup(r => r.GetSite(site.Id??0)).Returns(site); //Task.FromResult(sites));

        var result = await _controller.Get(site.Id??0);
        
        Assert.NotNull(result.Value);
        Assert.Equal(site, result.Value);
    }

     [Fact]
    public async Task When_CalledWithBadSiteId_Expect_ReturnsNotFound()
    {
        var sites = CreateSites();

        var site = sites[1];

        _repoMock.Setup(r => r.GetSite(site.Id??0)).Returns((Site?)null); //Task.FromResult(sites));

        var result = await _controller.Get(223);
        Assert.IsType<NotFoundResult>(result.Result);
    }
}
