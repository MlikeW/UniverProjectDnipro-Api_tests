namespace API.Messages.CartMes
{
    public class UpdateCartItem
    {
        public UpdateCartItem(int number, string operation = "INCREMENT") 
            => (this.number, this.operation) = (number, operation);

        public string operation { get; set; }
        public int number { get; set; }
    }
}
