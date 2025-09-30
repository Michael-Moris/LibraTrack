﻿namespace LibraTrack.Models
{
    public class Author : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public ICollection<Book> Books { get; set; } = [];
    }
}
