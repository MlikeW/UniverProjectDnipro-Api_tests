namespace API.Messages.OrdersMes
{
    public class Pageable

    {

        public Sort sort { get; set; }

        public int pageNumber { get; set; }

        public int pageSize { get; set; }

        public int offset { get; set; }

        public bool unpaged { get; set; }

        public bool paged { get; set; }

    }
}
