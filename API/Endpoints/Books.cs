using System.Net;
using API.Messages.BooksMes;
using API.Messages.OrdersMes;

namespace API.Endpoints
{
    internal class Books : BaseEndpoint
    {
        protected override string MainPoint { get; } = "books";
        private string BookPoint(int bookId) => GetChildPoint(bookId.ToString());

        public Books(Sender.Sender send) : base(send)
        {
        }

        public SingleBook CreateBook(string title)
            => (SingleBook)Send.Get<SingleBook>(MainPoint, HttpStatusCode.OK, new CreateBook(title));

    }
}