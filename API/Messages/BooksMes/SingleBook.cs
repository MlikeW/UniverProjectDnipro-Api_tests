using System.Collections.Generic;

namespace API.Messages.BooksMes
{
    public class SingleBook
    {
        public string id { get; set; }

        public string title { get; set; }

        public string description { get; set; }

        public double price { get; set; }

        public int quantity { get; set; }

        public IList<Author> authors { get; set; }

        public IList<string> genres { get; set; }

        public IList<string> tags { get; set; }
    }
}
