using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkersOnSite_2.Shared;
//using WorkersOnTeam_2_API.Controllers;

namespace WorkersOnSite_2_API.Model
{
  public class TeamRepository : ITeamRepository
  {
    static List<Team> _Teams = new List<Team>();

    readonly string _connectionString;

    public TeamRepository(IConfiguration config)
    {
      _connectionString = config.GetConnectionString("WorkersonSite2DB");
      LoadAllTeams();
    }

    private void LoadAllTeams()
    {
      using var db = new SqlConnection(_connectionString);
      _Teams = db.Query<Team>(@"
                                SELECT cast(TeamID as varchar(36)) TeamID     
                                      ,TeamName
                                      ,TeamLocation 
                                      ,TeamPhoneNumber
                                FROM Teams                                    
                                ").ToList();
    }

    public IEnumerable<Team> GetAllTeams()
    {
      return _Teams;
    }

    public async Task<Team> GetTeamByID(string TeamID)
    {
      using var db = new SqlConnection(_connectionString);
      var sql = @"
                  SELECT cast(TeamID as varchar(36)) TeamID     
                        ,TeamName
                        ,TeamLocation 
                        ,TeamPhoneNumber
                  FROM Teams  
                  WHERE TeamID = CAST(@TeamID AS uniqueidentifier)
                  ";

      var convertTeamIDToGUID = new
      {
        TeamID = TeamID
      };

      var TeamByID = await db.QueryFirstOrDefaultAsync<Team>(sql, convertTeamIDToGUID );
      return TeamByID;
    }


  }
}
