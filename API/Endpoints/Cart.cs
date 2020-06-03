namespace API.Endpoints
{
    class Cart : BaseEndpoint
    {
        protected override string MainPoint { get; } = "cart";
        private string UserCartPoint(int userId) => GetChildPoint(userId.ToString());
        private string UserCartBookPoint(int userId, int bookId) => GetChildPoint(userId.ToString(), bookId.ToString());

        public Cart(Sender.Sender send) : base(send)
        {
        }
    }
}
