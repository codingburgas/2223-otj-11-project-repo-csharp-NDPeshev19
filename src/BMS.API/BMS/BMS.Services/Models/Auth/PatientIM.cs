using BMS.Data.Models.Hospital;
using BMS.Data.Models.Misc;
using Microsoft.AspNetCore.Identity;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS.Services.Models.Auth;

public class PatientIM : AccountIM
{
    [Required]
    [MaxLength(90, ErrorMessage = "City name can't be more than 90 characters.")]
    [MinLength(3, ErrorMessage = "City name can't be less than 3 characters.")]
    [ProtectedPersonalData]
    public string? BornIn { get; set; }

    [Required]
    [ProtectedPersonalData]
    public DateOnly BornAt { get; set; }

    [Required]
    public int? BloodTypeId { get; set; }

    [Required]
    public bool IsTakingSpecialMedication { get; set; }

    [MaxLength(15, ErrorMessage = "Phone number is too long.")]
    [MinLength(9, ErrorMessage = "Phone number is too short.")]
    [ProtectedPersonalData]
    public string? EmergencyNumber { get; set; }

    [Required]
    public string? HospitalId { get; set; }
}
