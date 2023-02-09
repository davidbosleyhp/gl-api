namespace gl_api.test;
using gl_api.Data;

public class SiteDataTests
{
    [Fact]
    public void When_GetSitesCalled_Expect_Returns3Sites()
    {
        var siteData = new SiteData();
        var sites = siteData.GetSites();

        Assert.Equal(3, sites.Count);
    }
}