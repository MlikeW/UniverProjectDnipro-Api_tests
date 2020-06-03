using System.Collections.Generic;

namespace API.Messages.OrdersMes
{
    public class OrderDetails
    {
        public IList<OrderItem> orderItems { get; set; }
    }
}
