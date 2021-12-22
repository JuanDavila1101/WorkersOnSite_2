using System.Collections.Generic;
using System.Threading.Tasks;
using WorkersOnSite_2.Shared;

namespace WorkersOnSite_2_API.Model
{
  public interface ITeamRepository
  {
    IEnumerable<Team> GetAllTeams();
    Task<Team> GetTeamByID(string teamID);
  }
}