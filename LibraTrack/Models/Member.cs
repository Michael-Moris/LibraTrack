using LibraTrack.Models.Enum;
using System.ComponentModel.DataAnnotations;

namespace LibraTrack.Models
{
    public class Member : BaseEntity
    {
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        [RegularExpression(@"^[^@]+@[^@]+\.[^@]+$", ErrorMessage = "Invalid Email Format!")]
        public string Email { get; set; }

        [Required]
        [MaxLength(13)]
        [RegularExpression(@"^\+20[0-9]{9}$", ErrorMessage = "Phone Number Must Be in The Format +201234567890")]
        public string PhoneNumber { get; set; }

        public string Address { get; set; }
        public DateTime MembershipDate { get; set; }
        public MemberStatus Status { get; set; }
    }
}
