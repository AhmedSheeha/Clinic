using System.ComponentModel.DataAnnotations;

namespace Clinic.DTO
{
    public class AppointmentDto
    {
        [Required]
        public DateTime Start {  get; set; }
        [Required]
        public int DoctorId { get; set; }
        [Required]
        public string Details { get; set; }
        [Required]
        public int PatientId { get; set; }
    }
}
