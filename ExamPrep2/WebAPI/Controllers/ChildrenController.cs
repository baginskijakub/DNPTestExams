using Microsoft.AspNetCore.Mvc;
using WebAPI.Domain;
using WebAPI.EfcDataAccess;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ChildrenController : ControllerBase
{
    private readonly Context _context;

    public ChildrenController(Context context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult> AddChildAsync(Child child)
    {
        try
        {
            Child createdChild = await _context.AddChildAsync(child);
            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet]
    [Route("/ids")]
    public async Task<ActionResult<List<int>>> GetChildrenId()
    {
        try
        {
            List<int> list = await _context.GetChildrenId();
            return Ok(list);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    [HttpGet]
    public async Task<ActionResult<List<int>>> GetChildren()
    {
        try
        {
            List<Child> list = await _context.GetChildren();
            return Ok(list);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}