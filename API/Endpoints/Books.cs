namespace API.Endpoints
{
    internal class Books : BaseEndpoint
    {
        protected override string MainPoint { get; } = "books";
        private string BookPoint(int bookId) => GetChildPoint(bookId.ToString());

        public Books(Sender.Sender send) : base(send)
        {
        }

    }
}