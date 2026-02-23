using RestWithAspNet10.Model;
using RestWithAspNet10.Model.DTO;

namespace RestWithAspNet10.Interface;

public interface IPersonService
{
    Task<PersonDTO> Create(PersonDTO person);
    Task<PersonDTO> FindById(long id);
    Task<List<PersonDTO>> FindAll();
    Task<PersonDTO> Update(PersonDTO person);
    Task Delete(long id);
}
