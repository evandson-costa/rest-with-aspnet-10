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

    public PersonController(IPersonService personService)
    {
        _personService = personService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_personService.FindAll());
    }

    [HttpGet("{id}")]
    public IActionResult Get(long id)
    {
        var person = _personService.FindById(id);
        if (person == null) return NotFound();
        return Ok(person);

    }

    [HttpPost]
    public IActionResult Post([FromBody] Person person)
    {
        if (person == null) return BadRequest();
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
        if (updatedPerson == null) return NotFound();
        return Ok(updatedPerson);

    }
}
