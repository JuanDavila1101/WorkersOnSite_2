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
  public class TeamController : ControllerBase
  {
    private readonly ITeamRepository _TeamRepository;

    public TeamController(ITeamRepository TeamRepository)
    {
      _TeamRepository = TeamRepository;
    }

    // Get api/<controller>
    [HttpGet]
    public IActionResult GetTeams()
    {
      return Ok(_TeamRepository.GetAllTeams());
    }

    // Get api/<controller>/id
    [HttpGet("id")]
    public async Task<IActionResult> GetTeamByID(string TeamID)
    {
      var Team = await _TeamRepository.GetTeamByID(TeamID);

      return Ok(Team);
    }


  }
}
