using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebAPI.Models;

public class Team
{
    [Key]
    public string TeamName { get; set;}
    [Required, MaxLength(50)]
    public string NameOfCoach { get; set; }
    public int Ranking { get; set; }
    [NotMapped]
    public List<Player> Players { get; set; }
}