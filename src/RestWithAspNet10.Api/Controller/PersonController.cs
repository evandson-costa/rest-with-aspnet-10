using RestWithAspNet10.Interface;
using RestWithAspNet10.Utils;
using System;
using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using RestWithAspNet10.Model;

namespace RestWithAspNet10.Controller;

[ApiController]
[Route("[controller]")]
public class PersonController : ControllerBase
{
    private readonly IPersonService _personService;
    private readonly ILogger<PersonController> _logger;

    public PersonController(IPersonService personService, ILogger<PersonController> logger)
    {
        _personService = personService;
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Get()
    {
        _logger.LogInformation("Retrieving all persons");
        return Ok(_personService.FindAll());
    }

    [HttpGet("{id}")]
    public IActionResult Get(long id)
    {
        _logger.LogInformation("Retrieving by ID: {Id}", id);
        var person = _personService.FindById(id);
        if (person == null) return NotFound();
        return Ok(person);

    }

    [HttpPost]
    public IActionResult Post([FromBody] Person person)
    {
        _logger.LogInformation("Retrieving by first name {Id}", person.FirstName);
        if (person == null)
        {
            _logger.LogWarning("Received null person object");
            return BadRequest();
        }
        return Ok(_personService.Create(person));
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(long id)
    {
        _personService.Delete(id);
        return NoContent();
    }

    [HttpPut]
    public IActionResult Put([FromBody] Person person)
    {
        if (person == null) return BadRequest();
        var updatedPerson = _personService.Update(person);
        if (updatedPerson == null)
        {
            _logger.LogError("Person with ID {Id} not found for update", person.Id);
            return NotFound();
        } 
        return Ok(updatedPerson);
    }
}
