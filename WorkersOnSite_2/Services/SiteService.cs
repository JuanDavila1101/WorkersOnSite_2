
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WorkersOnSite_2.Shared;

namespace WorkersOnSite_2.Model
{
  public class SiteService : ISiteService
  {
    //static List<Site> _Sites = new List<Site>();

    private readonly HttpClient _httpClient;

    public SiteService(HttpClient httpClient)
    {
      _httpClient = httpClient;
    }

    private async Task<T> Get<T>(string url)
    {
      return await JsonSerializer.DeserializeAsync<T>
               (await _httpClient.GetStreamAsync(url), 
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
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

    public async Task<Site> GetSiteByID(string siteID)
    {
      return await Get<Site>($"api/site/{siteID}");
    }

    public async Task<Site> AddSite(Site site)
    {
      var siteJson = new StringContent(JsonSerializer.Serialize(site), Encoding.UTF8, "application/json");
      var response = await _httpClient.PostAsync("api/Site", siteJson);
      if (response.IsSuccessStatusCode)
      {
        return await JsonSerializer.DeserializeAsync<Site>(await response.Content.ReadAsStreamAsync());
      }
      return null;
    }

    public async Task<Site> UpdateSite(Site site)
    {
      var siteJson = new StringContent(JsonSerializer.Serialize(site), Encoding.UTF8, "application/json");
      var response = await _httpClient.PutAsync("api/Site", siteJson);
      if (response.IsSuccessStatusCode)
      {
        return await JsonSerializer.DeserializeAsync<Site>(await response.Content.ReadAsStreamAsync());
      }
      return null;
    }

    public async Task<bool> DeleteSite(string SiteID)
    {
      var response = await _httpClient.DeleteAsync($"api/Site/{SiteID}");
      if (response.IsSuccessStatusCode)
      {
        return await JsonSerializer.DeserializeAsync<bool>(await response.Content.ReadAsStreamAsync());
      }
      return false;
    }
  }
}
