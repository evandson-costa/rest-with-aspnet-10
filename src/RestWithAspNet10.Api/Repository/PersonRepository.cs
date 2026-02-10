using RestWithAspNet10.Interface;
using RestWithAspNet10.Model;

namespace RestWithAspNet10.repository;

public class PersonRepository : IPersonRepository
{

    private readonly MSSQLContext _context;

    public PersonRepository(MSSQLContext context)
    {
        _context = context;
    }

    public List<Person> FindAll()
    {
        return _context.Persons.ToList();
    }

    public Person Create(Person person)
    {
        _context.Persons.Add(person);
        _context.SaveChanges();
        return person;
    }

    public void Delete(long id)
    {
        var person = _context.Persons.SingleOrDefault(p => p.Id == id);
        if (person != null)
        {
            _context.Persons.Remove(person);
            _context.SaveChanges();
        }
    }


    public Person FindById(long id)
    {
        var person = _context.Persons.SingleOrDefault(p => p.Id == id);

        if (person == null)
            return null;
        else
            return person;
    }

    public Person Update(Person person)
    {

        var existingPerson = _context.Persons.SingleOrDefault(p => p.Id == person.Id);
        if (existingPerson == null)
            return null;

        _context.Entry(existingPerson).CurrentValues.SetValues(person);
        _context.SaveChanges();
        return person;
    }
}