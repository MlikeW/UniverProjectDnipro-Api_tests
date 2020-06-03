using CommonUtilities.Methods.CustomAttributes;

namespace API.Messages.OrdersMes
{
    public class OrdersByUser
    {
        public OrdersByUser(int userId) => this.userId = userId;

        [AddSingleParameterToUrl]
        public int userId { get; set; }
    }
}
