using System.Collections.Generic;

namespace API.Messages.BooksMes
{
    public class AllBooks
    {
        public IList<SingleBook> content { get; set; }

        public Pageable pageable { get; set; }

        public int totalPages { get; set; }

        public int totalElements { get; set; }

        public bool last { get; set; }

        public Sort sort { get; set; }

        public int numberOfElements { get; set; }

        public bool first { get; set; }

        public int size { get; set; }

        public int number { get; set; }

        public bool empty { get; set; }
    }
}
