using System.ComponentModel.DataAnnotations;

namespace Clinic.DTO
{
    public class SpecializationDto
    {
        [Required]
        public string Name { get; set; }
    }
}
