namespace gl_apiTests;
using Microsoft.AspNetCore.Mvc;

public class SiteControllerDeleteSiteTests : SiteControllerBase
{
    [Fact]
    public async Task When_CalledWithValidSiteId_Expect_SiteDeletedReturns200()
    {
        var site = CreateSite();

        _repoMock.Setup(r => r.GetSite(site.Id??0)).Returns(site);
        _repoMock.Setup(r => r.DeleteSite(site.Id??0)); //Task.FromResult(sites));

        var result = await _controller.DeleteSite(site.Id??0);
        
        Assert.IsType<NoContentResult>(result);       
    }

    [Fact]
    public async Task When_IdDoesNotExit_Expect_ReturnsNotFound()
    {
        var site = CreateSite();

        var result = await _controller.DeleteSite(734);
        Assert.IsType<NotFoundResult>(result);
    }
}
