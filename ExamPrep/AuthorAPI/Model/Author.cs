using System.ComponentModel.DataAnnotations;
using AuthorAPI.Model;

namespace Domain.Model;

public class Author
{
    [Key]
    public int Id { get; set; }
    [MaxLength(15), Required]
    public string FirstName { get; set; }
    [MaxLength(15), Required]
    public string LastName { get; set; }

    public Author(){}
}