using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Doctor 
{
	public int Id { get; set; }
	public string Name { get; set; }
	[EmailAddress]
	public string Phone { get; set; }
	public string Address { get; set; }
	[ForeignKey(nameof(Specialization))]
	public int SpecializationId	{ get; set; }
	[ForeignKey(nameof(ApplicationUser))]
	public string UserId { get; set; }
	public string Email {  get; set; }
	public ApplicationUser User { get; set; }
	public Specialization Specialization { get; set; }
	public ICollection<AppointMent> AppointMents { get; set; }

	public Doctor()
	{
		AppointMents = new Collection<AppointMent>();
	}
}
