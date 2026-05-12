using Microsoft.AspNetCore.Mvc;

namespace Model_Class.Models
{
    public class Book
    {
        [FromRoute]
        public int? BookId { get; set; }
        public string? Author { get; set; }

        public override string ToString()
        {
            return $"Book Id{BookId}, Author {Author}";
        }
    }
}
