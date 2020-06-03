using CommonUtilities.Methods.CustomAttributes;

namespace API.Messages.CartMes
{
    public class Quantity
    {
        public Quantity(int number) => (this.number) = (number);

        [AddSingleParameterToUrl]
        public int number { get; set; }
    }
}
