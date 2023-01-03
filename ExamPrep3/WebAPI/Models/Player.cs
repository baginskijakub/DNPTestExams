using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models;

public class Player
{
    [Key]
    public int Id { get; set; }
    [Required, MaxLength(50)]
    public string Name { get; set; }
    [Range(1,99)]
    public int ShirtNo { get; set; }
    public decimal Salary { get; set; }
    public int GoalsInSeason { get; set; }
    [Required]
    public string Position { get; set; }
    public string TeamName { get; set; }
    
}