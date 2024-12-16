using System.Diagnostics.Contracts;

namespace Clinic.DTO
{
    public class AttendanceDto
    {
        public string ClinincRemarks { get; set; }
        public string Diagnosis { get; set; }
        public string? SecondDiagnosis { get; set; }
        public string? ThirdDianosis { get; set; }
        public string Therepy { get; set; }
        public int PatientId { get; set; }
    }
}
