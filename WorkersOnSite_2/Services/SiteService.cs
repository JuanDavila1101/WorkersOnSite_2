using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using WorkersOnSite_2.Shared;

namespace WorkersOnSite_2.Model
{
  public class SiteService : ISiteService
  {
    static List<Site> _Sites = new List<Site>();

    private readonly HttpClient _httpClient;

    public SiteService(HttpClient httpClient)
    {
      _httpClient = httpClient;
    }

    private void LoadAllSites()
    {
      //using var db = new SqlConnection(_connectionString);
      //_Sites = db.Query<Site>(@"
      //                              SELECT SiteID          
      //                                    ,SiteFireBase    
      //                                    ,SiteFName       
      //                                    ,SiteMInitial    
      //                                    ,SiteLName       
      //                                    ,SiteSSN         
      //                                    ,SiteBirthday    
      //                                    ,SiteSalary      
      //                                    ,SitePhoneNumber1
      //                                    ,SitePhoneNumber2
      //                                    ,SiteType        
      //                              FROM Site                                    
      //                              ").ToList();
    }

    private async Task<T> Get<T>(string url)
    {
      return await JsonSerializer.DeserializeAsync<T>
               (await _httpClient.GetStreamAsync(url), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
    }

    private async Task<HttpResponseMessage> Post<T>(string url, T itemToPost)
    {
      var body = new StringContent(JsonSerializer.Serialize<T>(itemToPost));

      return await _httpClient.PostAsync(url, body);
    }

    private async Task<HttpResponseMessage> Put<T>(string url, T itemToPost)
    {
      var body = new StringContent(JsonSerializer.Serialize<T>(itemToPost));

      return await _httpClient.PutAsync(url, body);
    }

    public async Task<IEnumerable<Site>> GetAllSites()
    {
      return await Get<List<Site>>("api/site");
    }

    public async Task<Site> GetSiteByID(string SiteID)
    {
      return await Get<Site>($"api/site/{SiteID}");
    }

  }
}
