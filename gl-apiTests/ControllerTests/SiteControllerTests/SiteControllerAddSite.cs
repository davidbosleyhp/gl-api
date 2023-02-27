namespace gl_apiTests;
using Microsoft.AspNetCore.Mvc;

public class SiteControllerAddSiteTests : SiteControllerBase
{
    [Fact]
    public async Task When_CalledWithValidSite_Expect_SiteAddedReturns201()
    {
        var site = CreateSite();

        _repoMock.Setup(r => r.AddSite(site)).Returns(site); //Task.FromResult(sites));

        var result = await _controller.AddSite(site);
        // Assert.NotNull(result.Result.Value);
        // Assert.Equal(site, result.Value);
        Assert.IsType<CreatedAtRouteResult>(result.Result);
        var createdAtRouteResult = result.Result as CreatedAtRouteResult;
        Assert.NotNull(createdAtRouteResult!.Value);
        Assert.Equal(site, createdAtRouteResult.Value);
    }

    [Fact]
    public async Task When_CalledWithNoName_Expect_ReturnsBadRequest()
    {
        var site = CreateSite();
        site.Name = string.Empty;

        var result = await _controller.AddSite(site);
        Assert.IsType<BadRequestResult>(result.Result);
    }
}
