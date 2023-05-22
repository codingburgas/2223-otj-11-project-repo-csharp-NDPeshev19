using System.ComponentModel.DataAnnotations.Schema;

namespace BMS.Data.Models.Auth;

/// <summary>
/// Refresh token model.
/// </summary>
public class RefreshToken
{
    /// <summary>
    /// Gets or sets id of the refresh token.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets refresh token.
    /// </summary>
    public string? Token { get; set; }

    /// <summary>
    /// Gets or sets id of the user to which the refresh token belongs.
    /// </summary>
    public string? AccountId { get; set; }

    /// <summary>
    /// Gets or sets account to which the refresh token belongs.
    /// </summary>
    [ForeignKey(nameof(AccountId))]
    public Account? Account { get; set; }
}
