using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthorAPI.Model;

public class Book
{
    [Key]
    public int Isbn { get; set; }
    [MaxLength(40), Required]
    public string Title { get; set; }
    public int PublicationYear { get; set; }
    public int NumOfPages { get; set; }
    [ForeignKey("AuthorId")]
    public int AuthorId { get; set; }
    public string Genre { get; set; }
    
    public Book(){}

}