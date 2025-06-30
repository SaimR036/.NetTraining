using System.ComponentModel.DataAnnotations;

namespace T2.Models
{
    public class Book
    {
        [Key]
        public int isbn { get; set; }
        public string title { get; set; }
        public int quantity { get; set; }
        public Book(int isbn, string title, int quantity)
        {
            this.isbn = isbn;
            this.title = title;
            this.quantity = quantity > 0 ? quantity : 1;
        }
        public Book() { }

    }
}