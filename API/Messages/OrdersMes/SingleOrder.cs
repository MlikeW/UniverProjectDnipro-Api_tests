using System;

namespace API.Messages.OrdersMes
{
    public class SingleOrder
    {
        public string id { get; set; }
        public string userId { get; set; }
        public string addressLine { get; set; }
        public string status { get; set; }
        public OrderDetails orderDetails { get; set; }
        public DateTime placedAt { get; set; }

    }
}
