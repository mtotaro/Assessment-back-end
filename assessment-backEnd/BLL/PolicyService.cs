using DataAccess;
using DTO;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class PolicyService
    {
        public ClientDTO GetUserFromPolicy(Guid id)
        {
            PolicyRepository pRep = new PolicyRepository();

            return pRep.GetUserFromPolicy(id);

        }

        public List<PoliciesDTO> GetPoliciesFromUser(string name)
        {
            PolicyRepository pRep = new PolicyRepository();
            return pRep.GetByName(name);
        }
    }
}
