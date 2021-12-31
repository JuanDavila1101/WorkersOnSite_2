using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    [HttpGet("id")]
    public async Task<IActionResult> GetSiteByID(string SiteID)
    {
      var Site = await _SiteRepository.GetSiteByID(SiteID);

      return Ok(Site);
    }


  }
}
