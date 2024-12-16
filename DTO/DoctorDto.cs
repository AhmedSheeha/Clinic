using System.ComponentModel.DataAnnotations;

namespace Clinic.DTO
{
    public class DoctorDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public int SpecializationId { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
