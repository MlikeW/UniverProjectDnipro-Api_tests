using API.Messages.BooksMes;
using System.Net;

namespace API.Endpoints
{
    public class Books : BaseEndpoint
    {
        protected override string MainPoint { get; } = "books";
        private string BookPoint(string bookId) => GetChildPoint(bookId);

        public Books(Sender.Sender send) : base(send)
        {
        }

        public AllBooks GetAllBooks()
            => (AllBooks)Send.Get<AllBooks>(MainPoint);

        public SingleBook CreateBook(CreateBook book)
            => (SingleBook)Send.Post<SingleBook>(MainPoint, HttpStatusCode.OK, book);

        public void DeleteBook(string bookId)
            => Send.Delete<object>(BookPoint(bookId), HttpStatusCode.OK);

        public SingleBook GetSingleBook(string bookId)
            => (SingleBook)Send.Get<SingleBook>(BookPoint(bookId));

    }
}