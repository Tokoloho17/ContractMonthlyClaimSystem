namespace ContractMonthlyClaimSystem.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public int LecturerId { get; set; }
        public Lecturer Lecturer { get; set; }  // Navigation property to Lecturer

        public decimal TotalAmount { get; set; }
        public DateTime InvoiceDate { get; set; }

        public int ClaimId { get; set; }
        public Claim Claim { get; set; }  // Navigation property to Claim
    }
}
