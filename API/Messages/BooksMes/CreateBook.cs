using System.Collections.Generic;

namespace API.Messages.BooksMes
{
    public class CreateBook
    {
        public CreateBook(string title) => (this.title) = (title);

        public string title { get; set; }

        public string description { get; set; } = string.Empty;

        public string price { get; set; } = "19.99";

        public int quantity { get; set; } = 5;

        public IList<Author> authors { get; set; } = new List<Author> { new Author()};

        public IList<string> genres { get; set; } = new List<string>();

        public IList<string> tags { get; set; } = new List<string>();
    }
}
