using System.Collections.Generic;
using API.Messages.UserMes;
using System.Net;

namespace API.Endpoints
{
    public class Users : BaseEndpoint
    {
        protected override string MainPoint { get; } = "users";
        private string UserPoint(int userId) => GetChildPoint(userId.ToString());

        public Users(Sender.Sender send) : base(send)
        {
        }

        public List<SingleUser> GetAllUsersInStore()
            => (List<SingleUser>)Send.Get<List<SingleUser>>(MainPoint);

        public SingleUser CreateUserInStore(CreateUser user)
            => (SingleUser)Send.Post<SingleUser>(MainPoint, HttpStatusCode.OK, user);

        public SingleUser GetUserInStore(int userId)
            => (SingleUser)Send.Get<SingleUser>(UserPoint(userId));

        public void DeleteUserInStore(int userId)
            => Send.Delete<object>(UserPoint(userId), HttpStatusCode.NoContent);


    }
}