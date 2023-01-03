using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using WebAPI.Models;

namespace WebAPI.DataAccess;

public class Context : DbContext
{
    public DbSet<Player> Players { get; set; }
    public DbSet<Team> Teams { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source = Context.db");
    }

    public async Task<Team> CreateTeamAsync(Team team)
    {

            EntityEntry<Team> createdTeam = await Teams.AddAsync(team);
            await SaveChangesAsync();
            return createdTeam.Entity;

    }

    public async Task<List<Team>> GetTeams(int? ranking, string? teamName)
    {
        List<Team> allTeams =  Teams.ToList();
        List<Player> allPlayers = Players.ToList();
        foreach (var team in allTeams)
        {
            team.Players = new List<Player>();
            foreach (var player in allPlayers)
            {
                if (player.TeamName == team.TeamName)
                {
                    team.Players.Add(player);
                }
            }
        }
        if (ranking == null && teamName == null)
        {
            return allTeams;
        }
        else if (ranking != null && teamName == null)
        {
            List<Team> tempTeams = new List<Team>();
            foreach (var team in allTeams)
            {
                if (team.Ranking <= ranking)
                {
                    tempTeams.Add(team);
                }
            }

            return tempTeams;
        }
        else if (ranking == null && teamName != null)
        {
            List<Team> tempTeams = new List<Team>();
            foreach (var team in allTeams)
            {
                if (team.TeamName.ToLower().Contains(teamName.ToLower()))
                {
                    tempTeams.Add(team);
                }
            }
            return tempTeams;
        }
        else
        {
            List<Team> tempTeams = new List<Team>();
            foreach (var team in allTeams)
            {
                if (team.TeamName.ToLower().Contains(teamName.ToLower()) && team.Ranking <= ranking)
                {
                    tempTeams.Add(team);
                }
            }
            return tempTeams;
        }
    }

    public async Task<Player> CreatePlayerAsync(Player player, string teamname)
    {
        player.TeamName = teamname;
        EntityEntry<Player> createdPlayer = await Players.AddAsync(player);
        await SaveChangesAsync();
        return createdPlayer.Entity;
    }

    public async Task<bool> DeletePLayer(int id)
    {
        Console.WriteLine(id);
        List<Player> players = Players.ToList();
        Player existing = null;
        
        foreach (var player in players)
        {
            Console.WriteLine(player.Id);
            if (player.Id == id)
            {
                existing = player;
            }
        }

        if (existing != null)
        {
            Players.Remove(existing);
            await SaveChangesAsync();
            return true;
        }
        else
        {
            return false;
        }
    }
}