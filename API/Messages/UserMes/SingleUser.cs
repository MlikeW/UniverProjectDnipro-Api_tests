using System;

namespace API.Messages.UserMes
{
    public class SingleUser
    {

        public int ID { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public object DeletedAt { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

    }
}
