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

        public Books GetAllBooks(int bookId)
            => (Books)Send.Get<Books>(MainPoint, HttpStatusCode.OK);

        public SingleBook CreateBook(string title)
            => (SingleBook)Send.Post<SingleBook>(MainPoint, HttpStatusCode.OK, new CreateBook(title));

        public SingleBook GetSingleBook(int bookId)
            => (SingleBook)Send.Get<SingleBook>(BookPoint(bookId), HttpStatusCode.OK);

    }
}