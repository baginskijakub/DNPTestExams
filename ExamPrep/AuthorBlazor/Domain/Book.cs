

namespace AuthorBlazor.Domain;

public class Book
{
    public int Isbn { get; set; }
    public string Title { get; set; }
    public int PublicationYear { get; set; }
    public int NumOfPages { get; set; }
    public int AuthorId { get; set; }
    public string Genre { get; set; }
    
    public Book(){}

}