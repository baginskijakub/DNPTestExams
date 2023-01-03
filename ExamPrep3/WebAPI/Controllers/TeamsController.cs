using Microsoft.AspNetCore.Mvc;
using WebAPI.DataAccess;
using WebAPI.Models;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class TeamsController : ControllerBase
{
    private readonly Context _context;
    
    public TeamsController(Context context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult> CreateTeamAsync([FromBody] Team team)
    {
        Console.WriteLine("dupa");
        try
        {
            Team createdTeam = await _context.CreateTeamAsync(team);
            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet]
    public async Task<ActionResult<List<Team>>> GetTeams([FromQuery(Name = "ranking")] int? ranking, [FromQuery(Name = "teamname")] string? teamname)
    {
        try
        {
            List<Team> foundTeams = await _context.GetTeams(ranking, teamname);
            if (foundTeams.Count > 0)
            {
                return Ok(foundTeams);
            }
            else
            {
                return StatusCode(404, "Teams not found");
            }

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}