using Microsoft.AspNetCore.Mvc;
using WebAPI.Domain;
using WebAPI.EfcDataAccess;

namespace WebAPI.Controllers;

public class ToysController : ControllerBase
{
    private readonly Context _context;

    public ToysController(Context context)
    {
        _context = context;
    }
    
    [HttpPost]
    [Route("Toys/owner/{id:int}")]
    public async Task<ActionResult> AddToyAsync([FromBody]Toy toy, [FromRoute] int id)
    {
        toy.OwnerId = id;
        try
        {
            Toy createdToy = await _context.AddToyAsync(toy);
            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpDelete]
    [Route("Toys/{id:int}")]
    public async Task<ActionResult> DeleteToyASync([FromRoute] int id)
    {
        try
        {
            bool res  = await _context.DeleteToy(id);
            if (res)
            {
                return Ok();
            }
            else
            {
                return StatusCode(500);
            }

        }
        catch(Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }

        
    }
}