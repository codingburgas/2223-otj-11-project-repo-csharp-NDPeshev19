using BMS.Data.Models.Auth;

using Microsoft.AspNetCore.Identity;

using System.ComponentModel.DataAnnotations;

namespace BMS.Data.Models.Hospital;

/// <summary>
/// Represents a hospital in the identity system
/// </summary>
public class Hospital
{
    /// <summary>
    /// A GUID for the Id of the hospital
    /// </summary>
    [Required]
    public string? Id { get; set; }

    [Required]
    [PersonalData]
    public string? Name { get; set; }

    public List<Worker>? Workers { get; set; }

    public List<Patient>? Patients { get; set; }

    public List<BloodDonation>? BloodDonations { get; set; }
}
