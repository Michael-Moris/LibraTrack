using LibraTrack.Models.Enum;

namespace LibraTrack.Models
{
    public class Loan : BaseEntity
    {
        public DateTime LoanDate { get; set; }
        public LoanStatus Status { get; set; }

        public Fine Fine { get; set; }
    }
}
