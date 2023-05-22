﻿using BMS.Data.ExtensionMethods;
using BMS.Data.Helpers;
using BMS.Data.Models.Auth;
using BMS.Data.Models.Hospital;
using BMS.Data.Models.Misc;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace BMS.Data.Data;

public class ApplicationDbContext : IdentityDbContext
{
    // Auth
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Worker> Workers { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }

    // Normal data
    public DbSet<Hospital> Hospitals { get; set; }
    public DbSet<BloodDonation> BloodDonations { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.Entity<Account>()
            .ToTable("Accounts")
            .HasIndex(a => a.UserName)
            .IsUnique();

        builder.Entity<Patient>()
            .ToTable("Patients")
            .Property(p => p.BornAt)
            .HasConversion<DateOnlyConverter, DateOnlyComparer>();

        builder.Entity<Worker>()
            .ToTable("Workers");

        builder.Entity<Hospital>()
            .HasMany(h => h.Workers)
            .WithOne()
            .HasForeignKey(w => w.HospitalId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Hospital>()
            .HasMany(h => h.Patients)
            .WithOne()
            .HasForeignKey(p => p.HospitalId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Hospital>()
            .HasMany(h => h.BloodDonations)
            .WithOne()
            .HasForeignKey(bd => bd.HospitalId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<BloodDonation>()
            .HasOne(bd => bd.Donor)
            .WithMany()
            .HasForeignKey(bd => bd.DonorId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Entity<BloodDonation>()
            .HasOne(bd => bd.Recipient)
            .WithMany()
            .HasForeignKey(bd => bd.RecipientId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Entity<BloodDonation>()
            .HasOne(bd => bd.Hospital)
            .WithMany()
            .HasForeignKey(bd => bd.HospitalId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Entity<BloodType>()
            .Seed();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.ConfigureWarnings(conf => 
            conf.Ignore(RelationalEventId.ForeignKeyPropertiesMappedToUnrelatedTables));
    }
}


// FIXME: ADD SIZES TO ALL STRINGS TYPES BECAUSE THEY ARE VARCHAR(450)