using System.Collections.Generic;
using System.Threading.Tasks;
using WorkersOnSite_2.Shared;

namespace WorkersOnSite_2.Model
{
  public interface ISiteService
  {
    Task<IEnumerable<Site>> GetAllSites();
    Task<Site> GetSiteByID(string siteID);
  }
}