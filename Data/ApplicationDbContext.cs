using System;
using Clinic.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> context) : base(context) { }
	public DbSet<AppointMent> AppointMents { get; set; }
	public DbSet<Attendance> Attendances { get; set; }
	public DbSet<Doctor> Doctors { get; set; }
	public DbSet<Patient> Patients { get; set; }
	public DbSet<Specialization> Specializations { get; set; }
	public DbSet<DoctorAvailability> DoctorAvailability { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}
