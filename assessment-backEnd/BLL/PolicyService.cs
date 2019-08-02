using DataAccess;
using DTO;
using System;

namespace BLL
{
    public class PolicyService
    {
        public ClientDTO GetUserFromPolicy(Guid id)
        {
            PolicyRepository pRep = new PolicyRepository();

            return pRep.GetUserFromPolicy(id);

        }

        public ClientDTO GetByName(string name)
        {
            ClientRepository clRep = new ClientRepository();
            return clRep.GetByName(name);
        }
    }
}
