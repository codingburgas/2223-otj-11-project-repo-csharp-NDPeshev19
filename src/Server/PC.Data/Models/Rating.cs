using System.ComponentModel.DataAnnotations;
using PC.Data.Models.Accounts;

namespace PC.Data.Models;

public class Rating
{
    public string? Id { get; set; }
    
    [Range(1, 6)]
    public int RatingValue { get; set; }
    
    [Required]
    public string? ArticleId { get; set; }
    
    [Required]
    public string? UserId { get; set; }

    public Article? Article { get; set; }
    
    public User? User { get; set; }
}