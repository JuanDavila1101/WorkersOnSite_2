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
  public class PersonService : IPersonService
  {
    static List<Person> _persons = new List<Person>();

    private readonly HttpClient _httpClient;

    public PersonService(HttpClient httpClient)
    {
      _httpClient = httpClient;
    }

    private void LoadAllPeople()
    {
      //using var db = new SqlConnection(_connectionString);
      //_persons = db.Query<Person>(@"
      //                              SELECT PersonID          
      //                                    ,PersonFireBase    
      //                                    ,PersonFName       
      //                                    ,PersonMInitial    
      //                                    ,PersonLName       
      //                                    ,PersonSSN         
      //                                    ,PersonBirthday    
      //                                    ,PersonSalary      
      //                                    ,PersonPhoneNumber1
      //                                    ,PersonPhoneNumber2
      //                                    ,PersonType        
      //                              FROM PERSON                                    
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

    public async Task<IEnumerable<Person>> GetAllPersons()
    {
      return await Get<List<Person>>("api/person");
    }

    public async Task<Person> GetPersonByID(string personID)
    {
      return await Get<Person>($"api/person/{personID}");
    }

  }
}
