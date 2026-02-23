using Mapster;
using Microsoft.AspNetCore.Routing.Template;
using RestWithAspNet10.Interface;
using RestWithAspNet10.Model;
using RestWithAspNet10.Model.DTO;

namespace RestWithAspNet10.Services;

public class PersonService : IPersonService
{

    private readonly IPersonRepository _repository;

    public PersonService(IPersonRepository repository)
    {
        _repository = repository;
    }

    public async Task<PersonDTO> Create(PersonDTO person)
    {
        var map = person.Adapt<Person>();
        var createdPerson = await _repository.Create(map);
        return createdPerson.Adapt<PersonDTO>();
    }

    public async Task<List<PersonDTO>> FindAll()
    {
        var persons = await _repository.FindAll();
        return persons.Adapt<List<PersonDTO>>();
    }

    public async Task<PersonDTO> FindById(long id)
    {
        var person = await _repository.FindById(id);
        return person.Adapt<PersonDTO>();
    }

    public async Task<PersonDTO> Update(PersonDTO person)
    {
        var personToUpdate = person.Adapt<Person>();
        var updatedPerson = await _repository.Update(personToUpdate);
        return updatedPerson.Adapt<PersonDTO>();
    }

    public async Task Delete(long id)
    {
        await _repository.Delete(id);
    }
}