using System.Collections.Generic;

namespace API.Messages.OrdersMes
{
    public class Orders
    {
        public IList<SingleOrder> content { get; set; }

        public Pageable pageable { get; set; }

        public int totalElements { get; set; }

        public bool last { get; set; }

        public int totalPages { get; set; }

        public Sort sort { get; set; }

        public int numberOfElements { get; set; }

        public bool first { get; set; }

        public int size { get; set; }

        public int number { get; set; }

        public bool empty { get; set; }

    }
}
