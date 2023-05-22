﻿using BMS.Data.Models.Misc;

using Microsoft.AspNetCore.Identity;

using System.ComponentModel.DataAnnotations;

namespace BMS.Data.Models.Auth;

/// <summary>
/// Represents a patient <see cref="Account"/> in the identity system
/// </summary>
public class Patient : Account
{
    [Required]
    [MaxLength(90, ErrorMessage = "City name can't be more than 90 characters.")]
    [MinLength(3, ErrorMessage = "City name can't be less than 3 characters.")]
    [ProtectedPersonalData]
    public string? BornIn { get; set; }
    
    [Required]
    [ProtectedPersonalData]
    // FIXME: This will error on encoding to json. Write custom parser.
    public DateOnly BornAt { get; set; }

    [Required]
    public BloodType? BloodType { get; set; }

    [Required]
    public bool IsTakingSpecialMedication { get; set; }
    
    [MaxLength(15, ErrorMessage = "Phone number is too long.")]
    [MinLength(9, ErrorMessage = "Phone number is too short.")]
    [ProtectedPersonalData]
    public string? EmergencyNumber { get; set; }
}
