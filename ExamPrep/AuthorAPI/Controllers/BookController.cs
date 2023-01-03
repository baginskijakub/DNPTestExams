using AuthorAPI.EfcDataAccess;
using AuthorAPI.Model;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace AuthorAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{
    private readonly Context _context;

    public BookController(Context context)
    {
        _context = context;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<Book>>> GetAllAsync()
    {
        try
        {
            List<Book> books = await _context.GetAllBooksAsync();
            return Ok(books);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult> CreateBookAsync([FromBody]Book book)
    {
        try
        {
            await _context.CreateBook(book);
            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpDelete("{bookId:int}")]
    public async Task<ActionResult> DeleteBookAsync([FromRoute] int bookId)
    {
        try
        {
            await _context.DeleteBook(bookId);
            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}