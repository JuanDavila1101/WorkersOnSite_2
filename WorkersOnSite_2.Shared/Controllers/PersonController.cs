﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    [HttpGet("id")]
    public async Task<IActionResult> GetPersonByID(string personID)
    {
      var person = await _personRepository.GetPersonByID(personID);

      return Ok(person);
    }


  }
}
