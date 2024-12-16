using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Attendance
{
	[Key]
	public int Id { get; set; }
	public string ClinicRemarks { get; set; }
	public string Diagnosis { get; set; }
	public string? SecondDiagnosis { get; set; }
	public string? ThirdDiagnosis { get; set; }
	[ForeignKey(nameof(Doctor))]
	public int DoctorId { get; set; }
	public Doctor doctor { get; set; }
	public string Therapy { get; set; }

	public DateTime Date { get; set; }
	[ForeignKey(nameof(Patient))]
	public int PatientId { get; set; }
	public Patient Patient { get; set; }
	
}
