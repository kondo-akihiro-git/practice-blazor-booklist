using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Shared.Models
{
    public class Book
    {
        
        public string UserId { get; set; }
        [Key]
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }

        public Book(string userId, int bookId, string title, string author)
        {
            UserId = userId;
            BookId = bookId;
            Title = title;
            Author = author;
        }
    }
}

