namespace gl_apiTests;
using Microsoft.AspNetCore.Mvc;

public class SiteControllerUpdateSiteTests : SiteControllerBase
{
    [Fact]
    public async Task When_CalledWithValidSite_Expect_SiteUpdatedReturns200()
    {
        var site = CreateSite();

        _repoMock.Setup(r => r.GetSite(site.Id??0)).Returns(site);
        _repoMock.Setup(r => r.UpdateSite(site)); //Task.FromResult(sites));

        var result = await _controller.UpdateSite(site.Id??0, site);
        
        Assert.IsType<NoContentResult>(result);       
    }

    [Fact]
    public async Task When_CalledWithNoName_Expect_ReturnsBadRequest()
    {
        var site = CreateSite();
        site.Name = string.Empty;

        var result = await _controller.UpdateSite(site.Id??0, site);
        Assert.IsType<BadRequestResult>(result);
    }

      [Fact]
    public async Task When_IdDoesNotExit_Expect_ReturnsNotFound()
    {
        var site = CreateSite();

        var result = await _controller.UpdateSite(734, site);
        Assert.IsType<NotFoundResult>(result);
    }
}
