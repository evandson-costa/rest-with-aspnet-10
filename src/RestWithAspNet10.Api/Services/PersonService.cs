using Microsoft.AspNetCore.Routing.Template;
using RestWithAspNet10.Interface;
using RestWithAspNet10.Model;

namespace RestWithAspNet10.Services;

public class PersonService : IPersonService
{

    private readonly IPersonRepository _repository;

    public PersonService(IPersonRepository repository)
    {
        _repository = repository;
    }

    public Person Create(Person person)
    {
        return _repository.Create(person);
    }

    public void Delete(long id)
    {
        _repository.Delete(id);
    }

    public List<Person> FindAll()
    {

        return _repository.FindAll();
    }


    public Person FindById(long id)
    {
         return _repository.FindById(id);
    }

    public Person Update(Person person)
    {

        var personToUpdate = _repository.FindById(person.Id);

        personToUpdate.FirstName = person.FirstName;
        personToUpdate.LastName = person.LastName;
        personToUpdate.Address = person.Address;
        personToUpdate.Gender = person.Gender;

        _repository.Update(personToUpdate);
        return personToUpdate;
    }
}