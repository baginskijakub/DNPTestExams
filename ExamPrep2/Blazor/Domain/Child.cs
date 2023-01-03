using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Domain;

public class Child
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Gender { get; set; }
    [Required][Range(3,6)]
    public int Age { get; set; }
    [NotMapped]
    public List<Toy> toys { get; set; }

    public Child(){}
}