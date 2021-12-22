using System;
using WorkersOnSite_2.Shared;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using System.Linq;
using WorkersOnSite_2.Model;

namespace WorkersOnSite_2.Pages
{
  public partial class TeamOverview : ComponentBase
  {
    [Inject]
    public ITeamService TeamService { get; set; }

    [Parameter]
    public string TeamID { get; set; }
    public Team Team { get; set; } = new Team();
    public IEnumerable<Team> Teams { get; set; }

    protected async override Task OnInitializedAsync()
    {
      //InitializeTeam();
      Teams = await TeamService.GetAllTeams();
      Team = Teams.FirstOrDefault(p => p.TeamID == TeamID);
      base.OnInitializedAsync();
      return;
    }

    //private void InitializeTeam()
    //{
    //  var team1 = new Team
    //  {
    //    TeamID = "1",
    //    TeamName = "Team #1",
    //    TeamLocation = "Murfreesboro",
    //    TeamNumber = "1",
    //  };

    //  var team2 = new Team
    //  {
    //    TeamID = "2",
    //    TeamName = "Team #2",
    //    TeamLocation = "Murfreesboro2",
    //    TeamNumber = "2",
    //  };

    //  Teams = new List<Team> { team1, team2 };
    //}    
  }
}
