using System.Net;
using API.Messages.CartMes;

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

        public UserCart GetUserCart(int userId)
            => (UserCart)Send.Get<UserCart>(UserCartPoint(userId), HttpStatusCode.OK);

        public void ProcessOrderFromCart(int userId)
            => Send.Post<object>(UserCartPoint(userId), HttpStatusCode.OK);

        public void EmptyCart(int userId)
            => Send.Delete<object>(UserCartPoint(userId), HttpStatusCode.OK);

        public CartItem GetUserCartItem(int userId, int bookId)
            => (CartItem)Send.Get<CartItem>(UserCartBookPoint(userId, bookId), HttpStatusCode.OK);

        public void AddItemToCart(int userId, int bookId, int quantity = 1)
            => Send.Put<object>(UserCartBookPoint(userId, bookId), HttpStatusCode.OK, new Quantity(quantity));

        public CartItem UpdateQuantityOfItem(int userId, int bookId, int increaseCount)
            => (CartItem)Send.Post<CartItem>(UserCartBookPoint(userId, bookId), HttpStatusCode.OK, new UpdateCartItem(increaseCount));

        public void DeleteItemFromCart(int userId, int bookId)
            => Send.Delete<object>(UserCartBookPoint(userId, bookId), HttpStatusCode.OK);

    }
}
