using System.Net;
using API.Messages.OrdersMes;

namespace API.Endpoints
{
    public class Orders : BaseEndpoint
    {
        protected override string MainPoint { get; } = "orders";
        private string OrderPoint(int orderId) => GetChildPoint(orderId.ToString());
        
        public Orders(Sender.Sender send) : base(send)
        {
        }

        public AllOrders GetAllOrdersInfo()
            => (AllOrders)Send.Get<AllOrders>(MainPoint);

        public AllOrders GetUsersOrdersInfo(int userId)
            => (AllOrders)Send.Get<AllOrders>(MainPoint, HttpStatusCode.OK, new OrdersByUser(userId));

        public SingleOrder GetCurrentOrdersInfo(int orderId)
            => (SingleOrder)Send.Get<SingleOrder>(OrderPoint(orderId));

    }
}