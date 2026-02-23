using System.Text.Json.Serialization;

namespace RestWithAspNet10.Model.DTO;

public class PersonDTO
{
    public long Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Gender { get; set; }
    public required string Address { get; set; }
}