namespace LibraTrack.Models
{
    public class Category : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public ICollection<Book> Books { get; set; } = [];
    }
}
