using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

public class Patient
{
	public int Id { get; set; }
	public string Name { get; set; }
	public Gender Gender { get; set; }
	public DateTime BirthDate { get; set; }
	public string Phone {  get; set; }
	public string Address { get; set; }
	public double Height { get; set; }
	public double Weight { get; set; }
	public int Age { get
		{
			var now = DateTime.Now;
			var age = now.Year - BirthDate.Year;
			return age;
		} }

	public Patient()
	{
		AppointMents = new Collection<AppointMent>();
		Attendances = new Collection<Attendance>();
	}
	public ICollection<AppointMent> AppointMents { get; set; }
	public ICollection<Attendance> Attendances { get; set; }

}

public enum Gender
{
	[Description("Male")]
	Male = 1,
	[Description("Female")]
	Female
}