using System.Collections.Generic;
using API.Messages.UserMes;
using System.Net;

namespace API.Endpoints
{
    internal class Users : BaseEndpoint
    {
        protected override string MainPoint { get; } = "users";
        private string UserPoint(int userId) => GetChildPoint(userId.ToString());

        public Users(Sender.Sender send) : base(send)
        {
        }

        public List<SingleUser> GetAllUsersInStore()
            => (List<SingleUser>)Send.Get<List<SingleUser>>(MainPoint);

        public SingleUser CreateUserInStore(string name, int age, string email, string address)
            => (SingleUser)Send.Post<SingleUser>(MainPoint, HttpStatusCode.OK, new CreateUser(name, age, email, address));

        public SingleUser GetUserInStore(int userId)
            => (SingleUser)Send.Get<SingleUser>(UserPoint(userId), HttpStatusCode.OK);


    }
}