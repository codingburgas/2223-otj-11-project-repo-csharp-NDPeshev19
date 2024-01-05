using System.ComponentModel.DataAnnotations;

using PC.Data.Models.Accounts;

namespace PC.Data.Models;

public class Article 
{
    public string? Id { get; set; }

    [Required]
    public string? Title { get; set; }

    [Required]
    public string? Theme { get; set; }

    [Required]
    public string? Description { get; set; }
    
    public string? CreatedById { get; set; }
    
    public string? LastEditedById { get; set; }

    public List<ArticlePlacementStudent>? ArticlePlacementStudents { get; set; }

    public User? CreatedBy { get; set; }

    public User? LastEditedBy { get; set; }

    public List<Image>? Images { get; set; }

    public List<Rating>? Ratings { get; set; }
}
