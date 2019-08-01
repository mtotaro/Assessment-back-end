using DataAccess;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class ClientService
    {
        public ClientDTO GetById(Guid id)
        {
            ClientRepository clRep = new ClientRepository();
            return clRep.GetById(id);
        }

        public ClientDTO GetByName(string name)
        {
            ClientRepository clRep = new ClientRepository();
            return clRep.GetByName(name);
        }
    }
}
