using System.Net;
using API.Messages.OrdersMes;

namespace API.Endpoints
{
    class Orders : BaseEndpoint
    {
        protected override string MainPoint { get; } = "/orders";
        private string OrderPoint(int orderId) => GetChildPoint(orderId.ToString());
        
        public Orders(Sender.Sender send) : base(send)
        {
        }

        public Orders GetAllOrdersInfo()
            => (Orders)Send.Get<Orders>(MainPoint, HttpStatusCode.OK);

        public Orders GetUsersOrdersInfo(int userId)
            => (Orders)Send.Get<Orders>(MainPoint, HttpStatusCode.OK, new OrdersByUser(userId));

        public SingleOrder GetCurrentOrdersInfo(int orderId)
            => (SingleOrder)Send.Get<SingleOrder>(OrderPoint(orderId), HttpStatusCode.OK);

    }
}