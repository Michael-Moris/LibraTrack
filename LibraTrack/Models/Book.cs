using System.ComponentModel.DataAnnotations;

namespace LibraTrack.Models
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public decimal Price { get; set; }

        [Range(1950, int.MaxValue, ErrorMessage = "Publication Year Must Be 1950 or Later.")]
        public int PublicationYear { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Available Copies Must Be Non-Negative.")]
        public int AvailableCopies { get; set; }

        public int TotalCopies { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
