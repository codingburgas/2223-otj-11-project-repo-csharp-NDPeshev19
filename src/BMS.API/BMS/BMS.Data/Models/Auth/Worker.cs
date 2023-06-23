using Microsoft.AspNetCore.Identity;

using System.ComponentModel.DataAnnotations.Schema;

namespace BMS.Data.Models.Auth;

/// <summary>
/// Represents a Worker <see cref="Account"/> in the identity system
/// </summary>
public class Worker : Account
{
    public string? HospitalId { get; set; }

    /// <summary>
    /// Denotes the <see cref="Hospital"/> that the account belongs to.
    /// </summary>    
    [ForeignKey(nameof(HospitalId))]
    public Hospital.Hospital? Hospital { get; set; }
}
