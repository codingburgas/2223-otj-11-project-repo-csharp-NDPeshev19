using PC.Data.Models.Accounts;

namespace PC.Data.Models;

public class ArticlePlacementStudent
{
    public string? ArticleId { get; set; }
    
    public string? PlacementId { get; set; }

    public string? StudentId { get; set; }

    public Article? Article { get; set; }

    public Placement? Placement { get; set; }

    public Student? Student { get; set; }
}
