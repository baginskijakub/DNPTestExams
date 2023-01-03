using AuthorAPI.Model;
using Domain.Model;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace AuthorAPI.EfcDataAccess;

using Microsoft.EntityFrameworkCore;

public class Context : DbContext
{
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source = ../AuthorAPI/Context.db");
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>().HasKey(author => author.Id);
        modelBuilder.Entity<Book>().HasKey(book => book.Isbn);
    }

    public async Task CreateAuthor(Author author)
    {
        EntityEntry<Author> newAuthor = await Authors.AddAsync(author);
        await SaveChangesAsync();
        Console.WriteLine(newAuthor);
    }

    public async Task<List<Author>> GetAuthorsAsync()
    {
        IQueryable<Author> authors = Authors.AsQueryable();
        List<Author> list = await authors.ToListAsync();
        return list;
    }
    
    public async Task<List<Book>> GetAllBooksAsync()
    {
        IQueryable<Book> books = Books.AsQueryable();
        List<Book> list = await books.ToListAsync();
        return list;
    }

    public async Task CreateBook(Book book)
    {
        EntityEntry<Book> newBook = await Books.AddAsync(book);
        await SaveChangesAsync();
        Console.WriteLine(newBook);
    }

    public async Task DeleteBook(int bookId)
    {
        Book existing = await Books.FindAsync(bookId);
        if (existing == null)
        {
            throw new Exception($"Book with id: {bookId} not found");
        }
        Books.Remove(existing);
        await SaveChangesAsync();
    }
}