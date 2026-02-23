using RestWithAspNet10.Interface;
using RestWithAspNet10.Utils;
using System;
using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using RestWithAspNet10.Model;
using RestWithAspNet10.Model.DTO;

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
    public async Task<IActionResult> Get()
    {
        _logger.LogInformation("Retrieving all persons");

        // Adicione o 'await' aqui para extrair o resultado da Task
        return Ok(await _personService.FindAll());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(long id)
    {
        _logger.LogInformation("Retrieving by ID: {Id}", id);
        var person = await _personService.FindById(id);
        if (person == null) return NotFound();
        return Ok(person);

    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] PersonDTO person)
    {
        _logger.LogInformation("Retrieving by first name {Id}", person.FirstName);
        if (person == null)
        {
            _logger.LogWarning("Received null person object");
            return BadRequest();
        }
        return Ok(await _personService.Create(person));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        await _personService.Delete(id);
        return NoContent();
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromBody] PersonDTO person)
    {
        if (person == null) return BadRequest();
        var updatedPerson = await _personService.Update(person);
        if (updatedPerson == null)
        {
            _logger.LogError("Person with ID {Id} not found for update", person.Id);
            return NotFound();
        }
        return Ok(updatedPerson);
    }
}
