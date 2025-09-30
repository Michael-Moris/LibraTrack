using LibraTrack.Models.Enum;

namespace LibraTrack.Models
{
    public class Fine : BaseEntity
    {
        public int LoanId { get; set; }
        public Loan Loan { get; set; }

        public decimal Amount { get; set; }
        public DateTime IssuedDate { get; set; }
        public DateTime? PaidDate { get; set; }
        public FineStatus Status { get; set; }
    }
}
