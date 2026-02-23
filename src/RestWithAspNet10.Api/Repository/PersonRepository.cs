using RestWithAspNet10.Api.Interface.Base;
using RestWithAspNet10.Interface;
using RestWithAspNet10.Model;

namespace RestWithAspNet10.repository;

public class PersonRepository : IPersonRepository
{

    private readonly IGenericRepository<Person> _context;

    public PersonRepository(IGenericRepository<Person> context)
    {
        _context = context;
    }

    public async Task<List<Person>> FindAll()
    {
        return (await _context.GetAllAsync()).ToList();
    }

    public async Task<Person> Create(Person person)
    {
        await _context.CreateAsync(person);
        return person;
    }

    public async Task Delete(long id)
    {
        var person = await _context.GetByIdAsync(id);
        if (person != null)
        {
            await _context.DeleteAsync(id);
        }
    }

    public async Task<Person> FindById(long id)
    {
        var person = await _context.GetByIdAsync(id);

        if (person == null)
            return null;
        else
            return person;
    }

    public async Task<Person> Update(Person person)
    {

        await _context.UpdateAsync(person);
        return person;
    }
}