using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinic.Models
{
    public class DoctorAvailability
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(Doctor))]
        public int DoctorId { get; set; }
        public DayOfWeek Day { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool Available { get; set; }
    }
}
