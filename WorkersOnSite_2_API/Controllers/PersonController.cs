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
  public class PersonController : ControllerBase
  {
    private readonly IPersonRepository _personRepository;

    public PersonController(IPersonRepository personRepository)
    {
      _personRepository = personRepository;
    }

    // Get api/<controller>
    [HttpGet]
    public IActionResult GetPersons()
    {
      return Ok(_personRepository.GetAllPersons());
    }

    // Get api/<controller>/id
    //[HttpGet("id")]'
    [HttpGet("{personID}")]
    public async Task<IActionResult> GetPersonByID(string personID)
    {
      var person = await _personRepository.GetPersonByID(personID);

      return Ok(person);
    }

    [HttpPost]
    public async Task<IActionResult> AddPerson(Person person)
    {
      var personObject =  _personRepository.AddPerson(person);

      return Ok(personObject);
    }

    [HttpDelete("{personID}")]
    public IActionResult DeletePerson(string personID)
    {
      _personRepository.DeletePerson(personID);

      return Ok(true);

    }

    [HttpPut]
    public async Task<IActionResult> UpdatePerson (Person person)
    {
      var updatedPerson = _personRepository.UpdatePerson(person);

      return Ok(updatedPerson);
    }





    //// Get api/<controller>/id
    ////[HttpGet("id")]'
    //[HttpGet("api/person/{personID}")]
    //public IActionResult GetPersonByID(string personID)
    //{
    //  var person = _personRepository.GetPersonByID(personID);

    //  return Ok(person);
    //}






  }
}
