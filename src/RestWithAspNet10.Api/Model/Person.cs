
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithAspNet10.Model;

[Table("Person")]
public class Person
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public long Id { get; set; }

    [Column("first_name", TypeName = "varchar(80)")]
    [MaxLength(80)]
    [Required]
    public required string FirstName { get; set; }

    [Required]
    [Column("last_name", TypeName = "varchar(80)")]
    [MaxLength(80)]
    public required string LastName { get; set; }

    [Required]
    [Column("address", TypeName = "varchar(100)")]
    [MaxLength(100)]
    public required string Address { get; set; }

    [Required]
    [Column("gender", TypeName = "varchar(6)")]
    [MaxLength(6)]
    public required string Gender { get; set; }
}