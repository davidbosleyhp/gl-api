namespace gl_apiTests;

public class SiteControllerGetAllTests : SiteControllerBase
{
    [Fact]
    public async Task When_Called_Expect_ReturnsCorrectSites()
    {
        var sites = CreateSites();

        _repoMock.Setup(r => r.GetSites()).Returns(sites); //Task.FromResult(sites));

        var result = await _controller.Get();
        Assert.NotNull(result.Value);
        Assert.Equal(sites, result.Value);
    }
}
