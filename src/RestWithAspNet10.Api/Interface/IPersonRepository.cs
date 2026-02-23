using RestWithAspNet10.Model;

namespace RestWithAspNet10.Interface;

public interface IPersonRepository
{
    Task<Person> Create(Person person);
    Task<Person> FindById(long id);
    Task<List<Person>> FindAll();
    Task<Person> Update(Person person);
    Task Delete(long id);
}
