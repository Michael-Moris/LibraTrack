namespace LibraTrack.Models
{
    public class MemberLoans : BaseEntity
    {
        public int LoanId { get; set; }
        public Loan Loan { get; set; }

        public int MemberId { get; set; }
        public Member Member { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }

        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }

    }
}
