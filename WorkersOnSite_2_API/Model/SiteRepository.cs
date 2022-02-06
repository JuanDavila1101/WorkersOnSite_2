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

    public async Task<Site> GetSiteByID(string siteID)
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
        siteID = siteID
      };

      var SiteByID = await db.QueryFirstOrDefaultAsync<Site>(sql, convertSiteIDToGUID );
      return SiteByID;
    }



    public async Task<Site> AddSite(Site site)
    {
      using var db = new SqlConnection(_connectionString);
      var sql = @"
                  INSERT INTO Sites
                        ( SiteName
                         ,SiteLocation
                         ,SiteNumber
                         ,SiteStartTime
                         ,SiteIsCompleted
                         ,SitesTeamID
                         ,SitesPersonID)
                  VALUES (
                           @SiteName       
                          ,@SiteLocation   
                          ,@SiteNumber     
                          ,@SiteStartTime  
                          ,@SiteIsCompleted
                          ,(SELECT TOP(1) CAST(PersonID AS uniqueidentifier) FROM Person)
                          ,(SELECT TOP(1) CAST(TeamID AS uniqueidentifier) FROM Teams ) 
                          )";

      var parameters = new
      {
        SiteName = site.SiteName,
        SiteLocation = site.SiteLocation,
        SiteNumber = site.SiteNumber,
        SiteStartTime = site.SiteStartTime,
        SiteIsCompleted = site.SiteIsCompleted == true ? 1 : 0
      };

      var tempSite = db.QueryFirstOrDefault<Site>(sql, parameters);

      //HandleTeam(tempPerson);

      return tempSite;
    }

    //void HandleTeam(Person person)
    //{
    //  if (person == null) return;

    //  using var db = new SqlConnection(_connectionString);

    //  var sql = string.Empty;

    //  if (string.IsNullOrWhiteSpace(person.TeamID))
    //  {
    //    DeleteTeam(person.PersonID);
    //  }
    //  else
    //  {
    //    sql = @"
    //            IF NOT EXISTS(
    //                          SELECT * 
    //                          FROM PersonTeam
    //                          WHERE PersonTeamPersonID = CAST(@PersonID AS uniqueidentifier)
    //                          )
    //                          INSERT INTO PersonTeam
    //                                (
    //                                 PersonTeamPersonID
    //                                ,PersonTeamTeamID
    //                                 )
    //                          VALUES(
    //                                 @PersonID
    //                                ,@TeamID
    //                                 )
    //            ELSE 
    //                UPDATE PersonTeam
    //                SET PersonTeamTeamID = CAST(@TeamID AS uniqueidentifier)
    //                WHERE PersonTeamPersonID = CAST(@PersonID AS uniqueidentifier)
    //            ";
    //  }

    //  db.Execute(sql, person);
    //}

    //void DeleteTeam(string personID)
    //{
    //  using var db = new SqlConnection(_connectionString);
    //  var teamsql = @"
    //                  DELETE FROM PersonTeam
    //                  WHERE PersonTeamPersonID = CAST(@personID AS uniqueidentifier)
    //                  ";
    //  db.Execute(teamsql, new { personID });
    //}





    public async Task<Site> UpdateSite(Site site)
    {
      //HandleTeam(person);

      using var db = new SqlConnection(_connectionString);

      var sql = @"
                  UPDATE Sites 
                     SET  SiteName        = @SiteName
                         ,SiteLocation    = @SiteLocation
                         ,SiteNumber      = @SiteNumber
                         ,SiteStartTime   = @SiteStartTime
                         ,SiteIsCompleted = @SiteIsCompleted
                         ,SitesTeamID      = @SiteTeamID
                         ,SitesPersonID    = @SitePersonID
                  WHERE SiteID = CAST(@SiteID AS uniqueidentifier)
                   ";


      var parameters = new
      {
        SiteID = site.SiteID,
        SiteName = site.SiteName,
        SiteLocation = site.SiteLocation,
        SiteNumber = site.SiteNumber,
        SiteStartTime = site.SiteStartTime,
        SiteIsCompleted = site.SiteIsCompleted == true ? 1 : 0,
        SiteTeamID = site.SiteTeamID == null ? "" : site.SiteTeamID,
        SitePersonID = site.SitePersonID == null ? "" : site.SitePersonID
      };

      return db.QueryFirstOrDefault<Site>(sql, parameters);
    }

    public void DeleteSite(string siteID)
    {
      //DeleteTeam(personID);

      using var db = new SqlConnection(_connectionString);

      var sql = @"
                  DELETE 
                  FROM Sites
                  WHERE SiteID = CAST(@siteID  AS uniqueidentifier)
                  ";

      db.Execute(sql, new { siteID });
    }















  }
}
