using System;
using WorkersOnSite_2.Shared;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using System.Linq;

namespace WorkersOnSite_2.Pages
{
  public partial class SiteDetail
  {
    [Parameter]
    public string SiteID { get; set; }
    public Site Site { get; set; } = new Site();
    public IEnumerable<Site> Sites { get; set; }

    protected override Task OnInitializedAsync()
    {
      InitializeSite();
      Site = Sites.FirstOrDefault(p => p.SiteID == SiteID);
      return base.OnInitializedAsync();
    }

    private void InitializeSite()
    {
      var Site1 = new Site
      {
        SiteID = "1",
        SiteName = "Casa De Juan",
        SiteLocation = "Murfreesboro",
        SiteNumber = "1",
        SiteStartTime = new DateTime(2022, 1, 15),
        SiteIsCompleted = false,
        TeamID = "1",
        TeamAssigned = new Team(),
        PersonID = "1",
        SitePOCPerson = new Person(),
      };

      var Site2 = new Site
      {
        SiteID = "2",
        SiteName = "Casa De Danielle",
        SiteLocation = "Murfreesboro",
        SiteNumber = "2",
        SiteStartTime = new DateTime(2022, 1, 22),
        SiteIsCompleted = false,
        TeamID = "2",
        TeamAssigned = new Team(),
        PersonID = "2",
        SitePOCPerson = new Person(),
      };


      Sites = new List<Site> { Site1, Site2 };
    }    
  }
}
