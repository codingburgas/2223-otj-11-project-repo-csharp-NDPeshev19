using System.ComponentModel.DataAnnotations;

namespace PC.Data.Models;

public class Placement
{
    public string? Title { get; set; }

    [Required]
    public int Position { get; set; }

    public List<ArticlePlacementStudent>? ArticlePlacementStudents { get; set; }
}
