using System.Collections.Generic;

namespace API.Messages.CartMes
{
    public class UserCart
    {
        public int userId { get; set; }

        public IList<CartItem> items { get; set; }
    }
}
