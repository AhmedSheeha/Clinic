using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class AppointMent
{
	[Key]
	public int Id { get; set; }
	public DateTime StartDateTime { get; set; }
	public string Detail { get; set; }
	public bool Status { get; set; } = true;
	[ForeignKey(nameof(Patient))]
	public int PatientId { get; set; }
	public Patient Patient { get; set; }
	[ForeignKey(nameof(Doctor))]
	public int DoctorId { get; set; }
	public Doctor Doctor { get; set; }

	
}

