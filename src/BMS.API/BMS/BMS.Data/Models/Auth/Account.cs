using BMS.Data.Models.Misc;
using Microsoft.AspNetCore.Identity;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BMS.Data.Models.Auth;

/// <summary>
/// The abstract class for the Account
/// </summary>
public abstract class Account : IdentityUser
{
    [Required(ErrorMessage = "First name is required.")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "First name must be between 3 and 50 characters.")]
    [PersonalData]
    public string? FirstName { get; set; }

    [Required(ErrorMessage = "Middle name is required.")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Middle name must be between 3 and 50 characters.")]
    [PersonalData]
    public string? MiddleName { get; set; }

    [Required(ErrorMessage = "Last name is required.")]
    [MaxLength(50, ErrorMessage = "Last name can't be more than 50 characters.")]
    [MinLength(3, ErrorMessage = "Last name can't be less than 3 characters.")]
    [PersonalData]
    public string? LastName { get; set; }

    [Required(ErrorMessage = "Email is required.")]
    [ProtectedPersonalData]
    new public string? Email { get; set; }

    [Required(ErrorMessage = "Username is required.")]
    // TODO: Set to be unique in Fluent API.
    [ProtectedPersonalData]
    new public string? UserName { get; set; }

    /// <summary>
    /// Unique Citizenship Number
    /// </summary>
    /// <remarks>
    /// UCN is the bulgarian <b>EGN</b> in english.
    /// </remarks>
    [Required(ErrorMessage = "UCN is required.")]
    [StringLength(10, ErrorMessage = "UCN must be exactly 10 ")]
    [ProtectedPersonalData]
    public string? UCN { get; set; }

    [Required(ErrorMessage = "Gender is required.")]
    [PersonalData]
    public Gender Gender { get; set; }

    [Required]
    [MaxLength(15, ErrorMessage = "Phone number is too long.")]
    [MinLength(9, ErrorMessage = "Phone number is too short.")]
    [ProtectedPersonalData]
    new public string? PhoneNumber { get; set; }

    [Required]
    public string? HospitalId { get; set; }

    /// <summary>
    /// Denotes the <see cref="Hospital"/> that the account belongs to.
    /// </summary>    
    [ForeignKey(nameof(HospitalId))]
    public Hospital.Hospital? Hospital { get; set; }
}
