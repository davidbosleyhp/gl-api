namespace gl_apiTests;

using gl_api;
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

     [Fact]
    public void When_GetSiteCalled_Expect_ReturnsSite()
    {
        var siteData = new SiteData();
        var site = siteData.GetSite(2);

        Assert.NotNull(site);
        Assert.Equal(2, site.Id);
    }

    [Fact]
    public void When_AddSiteCalled_Expect_AddedAndReturnsSite()
    {
        var siteData = new SiteData();
        var site =new Site("fred") {Id=0, GeoLocation="", Altitude = 43, SeismicZone=1};

        var returnSite = siteData.AddSite(site);
        Assert.NotNull(returnSite);
        Assert.NotEqual(0, returnSite.Id);
    }

      [Fact]
    public void When_UpdateSiteCalled_Expect_Updated()
    {
        var siteData = new SiteData();
        var site =new Site("fred") {Id=0, GeoLocation="", Altitude = 43, SeismicZone=1};

        var returnSite = siteData.AddSite(site);

        returnSite.Name = "aha!";

        siteData.UpdateSite(returnSite);

        var afterUpdateSite = siteData.GetSite(returnSite.Id??0);

        Assert.NotNull(afterUpdateSite);
        Assert.Equal("aha!", returnSite.Name);
    }

       [Fact]
    public void When_DeleteSiteCalled_Expect_Deleted()
    {
        var siteData = new SiteData();
        var site =new Site("fred") {Id=0, GeoLocation="", Altitude = 43, SeismicZone=1};

        var returnSite = siteData.AddSite(site);
        siteData.DeleteSite(returnSite.Id??0);

        var afterUpdateSite =siteData.GetSite(returnSite.Id??0);

        Assert.Null(afterUpdateSite);
    }
}
