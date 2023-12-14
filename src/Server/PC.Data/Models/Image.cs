using System.ComponentModel.DataAnnotations;

namespace PC.Data.Models;

public class Image
{
    public string? ImageUrl { get; set; }

    [Required]
    public string? ArticleId { get; set; }

    [Required]
    public int Position { get; set; }

    public Article? Article { get; set; }
}
