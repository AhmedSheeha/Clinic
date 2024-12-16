using System.ComponentModel.DataAnnotations;

namespace Clinic.DTO
{
    public class PatientDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public Gender Gender { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public double Height { get; set; }
        [Required]
        public double Weight { get; set; }
    }
}
