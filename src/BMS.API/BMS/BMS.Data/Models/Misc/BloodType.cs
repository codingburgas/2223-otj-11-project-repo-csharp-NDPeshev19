using Microsoft.EntityFrameworkCore;

namespace BMS.Data.Models.Misc;

/// <summary>
/// Represents the blood group of a person with the Rh factor
/// </summary>
public class BloodType
{
    public int Id { get; set; }
    public BloodGroup Group { get; set; }
    public RhFactor RhFactor { get; set; }
}

/// <summary>
/// Represents the blood group of a person
/// </summary>
public enum BloodGroup
{
    O, 
    A, 
    B, 
    AB
}

/// <summary>
/// Represents the Rh Factor of a person
/// </summary>
public enum RhFactor
{
    Positive, 
    Negative
}
