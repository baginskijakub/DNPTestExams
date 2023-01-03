using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Domain;

public class Toy
{
    [Key]
    public int Id { get; set; }
    [Required, MaxLength(20)]
    public string Name { get; set; }
    public string Color { get; set; }
    public string Condition { get; set; }
    public bool IsFavourite { get; set; }
    public int OwnerId { get; set; }

    public Toy(){}
}