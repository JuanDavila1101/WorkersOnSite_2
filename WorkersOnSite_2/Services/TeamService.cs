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
  public class TeamService : ITeamService
  {
    static List<Team> _Teams = new List<Team>();

    private readonly HttpClient _httpClient;

    public TeamService(HttpClient httpClient)
    {
      _httpClient = httpClient;
    }

    private void LoadAllTeams()
    {
      //using var db = new SqlConnection(_connectionString);
      //_Teams = db.Query<Team>(@"
      //                              SELECT TeamID          
      //                                    ,TeamFireBase    
      //                                    ,TeamFName       
      //                                    ,TeamMInitial    
      //                                    ,TeamLName       
      //                                    ,TeamSSN         
      //                                    ,TeamBirthday    
      //                                    ,TeamSalary      
      //                                    ,TeamPhoneNumber1
      //                                    ,TeamPhoneNumber2
      //                                    ,TeamType        
      //                              FROM Team                                    
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

    public async Task<IEnumerable<Team>> GetAllTeams()
    {
      return await Get<List<Team>>("api/team");
    }

    public async Task<Team> GetTeamByID(string TeamID)
    {
      return await Get<Team>($"api/team/{TeamID}");
    }

  }
}
