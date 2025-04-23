namespace BookApi.Models
{
    public class Book
    {
        public int Id { get; set; }  // Primary key
        public string ?Title { get; set; }
        public string ?Author { get; set; }
    }
}
