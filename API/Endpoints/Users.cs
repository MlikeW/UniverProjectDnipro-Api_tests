namespace API.Endpoints
{
    internal class Users : BaseEndpoint
    {
        protected override string MainPoint { get; } = "users";
        private string UserPoint(int userId) => GetChildPoint(userId.ToString());

        public Users(Sender.Sender send) : base(send)
        {
        }

    }
}