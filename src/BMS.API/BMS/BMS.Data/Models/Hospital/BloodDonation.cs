﻿using BMS.Data.Models.Auth;
using BMS.Data.Models.Misc;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BMS.Data.Models.Hospital;

/// <summary>
/// Represents a blood donation in the identity system
/// </summary>
public class BloodDonation
{
    /// <summary>
    /// A GUID for the Id of the blood donation
    /// </summary>
    [Required]
    public string? Id { get; set; }

    [Required]
    public BloodType? BloodType { get; set; }

    [Required]
    public string? DonorId { get; set; }

    [Required]
    public string? RecipientId { get; set; }

    [Required]
    public string? HospitalId { get; set; }
    
    /// <summary>
    /// The amount of blood donated measured in <b>ml</b>
    /// </summary>
    [Required]
    public int Amount { get; set; }

    [Required]
    [ForeignKey(nameof(DonorId))]
    public Patient? Donor { get; set; }

    [Required]
    [ForeignKey(nameof(RecipientId))]
    public Patient? Recipient { get; set; }

    [Required]
    [ForeignKey(nameof(HospitalId))]
    public Hospital? Hospital { get; set; }
}