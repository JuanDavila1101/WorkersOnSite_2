using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkersOnSite_2.Shared;
using WorkersOnSite_2_API.Model;

namespace WorkersOnSite_2_API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class SiteController : ControllerBase
  {
    private readonly ISiteRepository _SiteRepository;

    public SiteController(ISiteRepository SiteRepository)
    {
      _SiteRepository = SiteRepository;
    }

    // Get api/<controller>
    [HttpGet]
    public IActionResult GetSites()
    {
      return Ok(_SiteRepository.GetAllSites());
    }

    // Get api/<controller>/id
    [HttpGet("{siteID}")]
    public async Task<IActionResult> GetSiteByID(string siteID)
    {
      var site = await _SiteRepository.GetSiteByID(siteID);

      return Ok(site);
    }


    [HttpPost]
    public async Task<IActionResult> AddSite(Site site)
    {
      var siteObject = _SiteRepository.AddSite(site);

      return Ok(siteObject);
    }

    [HttpDelete("{SiteID}")]
    public IActionResult DeleteSite(string SiteID)
    {
      _SiteRepository.DeleteSite(SiteID);

      return Ok(true);

    }

    [HttpPut]
    public async Task<IActionResult> UpdateSite(Site site)
    {
      var updatedSite = _SiteRepository.UpdateSite(site);

      return Ok(updatedSite);
    }

  }
}
