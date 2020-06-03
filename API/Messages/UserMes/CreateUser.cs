using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Messages.UserMes
{
    public class CreateUser
    {
        public CreateUser(string name, int age, string email, string address)
            => (Name, Age, Email, Address) = (name, age, email, address);

        public string Name { get; set; }

        public int Age { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }
    }
}
