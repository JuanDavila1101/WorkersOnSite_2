using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
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

    //private async Task<T> Get<T>(string url, T itemToGet)
    //{
    //  var body = new StringContent(JsonSerializer.Serialize<T>(itemToGet));

    //  return await _httpClient.GetAsync(url, body);

    //  //return await JsonSerializer.DeserializeAsync<T>
    //  //         (await _httpClient.GetStreamAsync(url), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
    //}


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
      //return await GetAsync<Person>($"api/person/{personID}");
      return await Get<Person>($"api/person/{personID}");
    }

    //public async Task<Person> GetPersonByID(string personID)
    //{
    //  return await Get<Person>($"api/person/{personID}");
    //  //return await Get<Person>($"api/person/{personID}");
    //}

    //public Person GetPersonByID(string personID)
    //{
    //  return Get<Person>($"api/person/{personID}");
    //  //return await Get<Person>($"api/person/{personID}");
    //}

    //public async Task<Person> GetPersonByID(Person person)
    //{

    //  var personJson = new StringContent(JsonSerializer.Serialize(person), Encoding.UTF8, "api/json");

    // return await _httpClient.PutAsync("api/person", personJson);

    //  //return await GetAsync<Person>($"api/person/{personID}");
    //  //return await Get<Person>($"api/person/{personID}");
    //}

    public async Task<Person> AddPerson(Person person)
    {
      var personJson = new StringContent(JsonSerializer.Serialize(person), Encoding.UTF8, "api/json");
      var response = await _httpClient.PatchAsync("api/person", personJson);

      if (response.IsSuccessStatusCode)
      {
        return await JsonSerializer.DeserializeAsync<Person>(await response.Content.ReadAsStreamAsync());
      }

      return null;
    }

    public async Task UpdatePerson(Person person)
    {
      var personJson = new StringContent(JsonSerializer.Serialize(person), Encoding.UTF8, "api/json");

      await _httpClient.PutAsync("api/person", personJson);
    }

    public async Task DeletePerson(string personID)
    {
      await _httpClient.DeleteAsync($"api/person{personID}");
    }

    //public async Task DeletePerson(string personID)
    //{
    //  await _httpClient.DeleteAsync($"api/person{personID}");
    //}


  }
}
