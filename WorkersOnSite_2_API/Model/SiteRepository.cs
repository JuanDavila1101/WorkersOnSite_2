using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkersOnSite_2.Shared;
using WorkersOnSite_2_API.Controllers;

namespace WorkersOnSite_2_API.Model
{ 
  public class SiteRepository : ISiteRepository
  {
    static List<Site> _Sites = new List<Site>();

    readonly string _connectionString;

    public SiteRepository(IConfiguration config)
    {
      _connectionString = config.GetConnectionString("WorkersonSite2DB");
      LoadAllSites();
    }

    private void LoadAllSites()
    {
      using var db = new SqlConnection(_connectionString);
      _Sites = db.Query<Site>(@"
                                SELECT CAST(SiteID AS varchar(36)) SiteID     
                                      ,SiteName
                                      ,SiteLocation
                                      ,SiteNumber
                                      ,SiteStartTime
                                      ,SiteIsCompleted
                                      ,SitesTeamID
                                      ,SitesPersonID       
                                FROM Sites                                    
                                ").ToList();
    }

    public IEnumerable<Site> GetAllSites()
    {
      return _Sites;
    }

    public async Task<Site> GetSiteByID(string SiteID)
    {
      using var db = new SqlConnection(_connectionString);
      var sql = @"
                  SELECT CAST(SiteID AS varchar(36)) SiteID     
                        ,SiteName
                        ,SiteLocation
                        ,SiteNumber
                        ,SiteStartTime
                        ,SiteIsCompleted
                        ,SitesTeamID
                        ,SitesPersonID       
                  FROM Sites    
                  WHERE SiteID = CAST(@SiteID AS uniqueidentifier)
                  ";

      var convertSiteIDToGUID = new
      {
        SiteID = SiteID
      };

      var SiteByID = await db.QueryFirstOrDefaultAsync<Site>(sql, convertSiteIDToGUID );
      return SiteByID;
    }


  }
}
