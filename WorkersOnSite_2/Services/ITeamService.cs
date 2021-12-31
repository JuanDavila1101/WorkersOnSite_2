using System.Collections.Generic;
using System.Threading.Tasks;
using WorkersOnSite_2.Shared;

namespace WorkersOnSite_2.Model
{
  public interface ITeamService
  {
    Task<IEnumerable<Team>> GetAllTeams();
    Task<Team> GetTeamByID(string teamID);
  }
}