using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using WorkersOnSite_2.Model;
using WorkersOnSite_2.Shared;

namespace WorkersOnSite_2.Pages
{
  public partial class SiteEdit
  {
    [Inject]
    public ISiteService SiteService { get; set; }
    [Inject]
    public ITeamService TeamService { get; set; }


    [Parameter]
    public string SiteID { get; set; }

    [Inject]
    NavigationManager NavigationManager { get; set; }

    public Site Site { get; set; } = new Site();
    //public List<Team> Teams { get; set; } = new List<Team>();

    protected string Message = string.Empty;
    protected string StatusClass = string.Empty;
    protected bool Saved;

    private ElementReference siteLocationRef;

    //protected async override Task OnAfterRenderAsync(bool firstRender)
    //{
    //  await SiteLastName.FocusAsync();
    //}

    protected override async Task OnInitializedAsync()
    {
      Saved = false;
      //Teams = (await TeamService.GetAllTeams()).ToList();

      //BigInteger.TryParse(SiteID, out var SiteID);

      if (string.IsNullOrEmpty(SiteID))
      {
        Site = new Site
        {
          SiteName = "Casa",
          SiteLocation = "Murfreesboro",
          SiteNumber = "1",
          SiteStartTime = DateTime.Now,
          SiteIsCompleted = false,
          SiteTeamID = "",
          TeamAssigned = new Team(),
          SitePersonID = "",
          SitePOCPerson = new Person(),
        };
      }
      else
      {
        Site = await SiteService.GetSiteByID(SiteID);
        //Site = SiteService.GetSiteByID(SiteID);

        // Sites = await SiteService.GetAllSites();
        // Site = Sites.FirstOrDefault(p => p.SiteID == SiteID);

      }

    }

    protected async Task HandleValidSubmit()
    {
      Saved = false;
      Site.SiteID = SiteID;
      
      if (string.IsNullOrEmpty(Site.SiteID))
      {
        var addedSite = await SiteService.AddSite(Site);
        if(addedSite != null)
        {
          StatusClass = "alert-success";
          Message = "The new Site was added successfully.";
          Saved = true;
        }
        else
        {
          StatusClass = "alert-danger";
          Message = $"Something went wrong while trying to add the new Site. {Environment.NewLine}Please try again.";
        }
      }
      else
      {
        //await SiteService.UpdateSite(Site);
        await SiteService.UpdateSite(Site);
        StatusClass = "alert-success";
        Message = "The Site was updated successfully.";
        Saved = true;

      }

    }

    public void HandleInvalidSubmit()
    {
      StatusClass = "alert-danger";
      Message = $"There is some type of violation error. {Environment.NewLine}Please try again.";
    }

    protected async Task DeleteSite()
    {
      await SiteService.DeleteSite(Site.SiteID);
      StatusClass = "alert-success";
      Message = "Deleted the Site successfully.";
      Saved = true;
    }

    protected void NavigateToOverview()
    {
      NavigationManager.NavigateTo("/siteoverview");
    }



  }
}
