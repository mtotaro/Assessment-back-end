using System;
using System.Collections.Generic;

namespace Models
{
    public class Clients
    {
        public List<Client> clients { get; set; }
    }

    public class Client
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}
