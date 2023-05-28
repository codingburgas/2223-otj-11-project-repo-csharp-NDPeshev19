﻿using BMS.Data.Models.Misc;

using System.ComponentModel.DataAnnotations;

namespace BMS.Services.Models.Auth;

public abstract class AccountIM
{
    [Required(ErrorMessage = "First name is required.")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "First name must be between 3 and 50 characters.")]
    public string? FirstName { get; set; }

    [Required(ErrorMessage = "Middle name is required.")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Middle name must be between 3 and 50 characters.")]
    public string? MiddleName { get; set; }

    [Required(ErrorMessage = "Last name is required.")]
    [MaxLength(50, ErrorMessage = "Last name can't be more than 50 characters.")]
    [MinLength(3, ErrorMessage = "Last name can't be less than 3 characters.")]
    public string? LastName { get; set; }

    [Required(ErrorMessage = "Email is required.")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Username is required.")]
    public string? UserName { get; set; }

    /// <summary>
    /// Unique Citizenship Number
    /// </summary>
    /// <remarks>
    /// UCN is the bulgarian <b>EGN</b> in english.
    /// </remarks>
    [Required(ErrorMessage = "UCN is required.")]
    [StringLength(10, ErrorMessage = "UCN must be exactly 10 ")]
    public string? UCN { get; set; }

    [Required(ErrorMessage = "Gender is required.")]
    public Gender Gender { get; set; }

    [Required]
    [MaxLength(15, ErrorMessage = "Phone number is too long.")]
    [MinLength(9, ErrorMessage = "Phone number is too short.")]
    public string? PhoneNumber { get; set; }
}