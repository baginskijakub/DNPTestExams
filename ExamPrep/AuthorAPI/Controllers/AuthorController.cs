using AuthorAPI.EfcDataAccess;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace AuthorAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthorController : ControllerBase
{
    private readonly Context _context;

    public AuthorController(Context context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult> CreateAsync(Author author)
    {
        try
        {
            await _context.CreateAuthor(author);
            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet]
    public async Task<ActionResult<List<Author>>> GetAllAsync()
    {
        try
        {
            List<Author> authors= await _context.GetAuthorsAsync();
            return Ok(authors);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

}