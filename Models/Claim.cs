namespace ContractMonthlyClaimSystem.Models
{
    public class Claim
    {
        public int Id { get; set; }

        // Reference to Lecturer
        public int LecturerId { get; set; }
        public Lecturer Lecturer { get; set; } // Navigation Property

        public double HoursWorked { get; set; }
        public double HourlyRate { get; set; }

        // Calculated Property for TotalAmount
        public double TotalAmount => HoursWorked * HourlyRate;

        public string Status { get; set; }
        public string Description { get; set; }
        public string DocumentPath { get; set; } // Path for uploaded documents

    }
}
