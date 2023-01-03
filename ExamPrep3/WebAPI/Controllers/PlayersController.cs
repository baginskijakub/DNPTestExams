using Microsoft.AspNetCore.Mvc;
using WebAPI.DataAccess;
using WebAPI.Models;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class PlayersController : ControllerBase
{
    private readonly Context _context;

    public PlayersController(Context context)
    {
        _context = context;
    }

    [HttpPost]
    [Route("{teamname}")]
    public async Task<ActionResult> CreatePlayerAsync([FromRoute] string teamname, [FromBody] Player player)
    {
        try
        {
            Player createdPlayer = await _context.CreatePlayerAsync(player, teamname);
            return Ok(createdPlayer);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return StatusCode(500, e.Message);
        }
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult> DeletePlayer([FromRoute] int id)
    {
        try
        {
            bool res = await _context.DeletePLayer(id);
            if (res)
            {
                return Ok();
            }
            else
            {
                return StatusCode(404, "Player with such id not found");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}