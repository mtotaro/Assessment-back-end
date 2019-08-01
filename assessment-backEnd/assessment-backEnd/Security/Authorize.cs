using BLL;
using DTO.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assessment_backEnd.Security
{
    public static class Authorize
    {
        public static int AuthorizeClient(string clientId, params string[] roles)
        {
            try
            {
                Guid cookieValueGuid = new Guid();
                if (String.IsNullOrWhiteSpace(clientId) || !(Guid.TryParse(clientId, out cookieValueGuid)))
                {
                    return 400;
                }
                else
                {
                    ClientService clService = new ClientService();
                    var client = clService.GetById(cookieValueGuid);

                    if (client == null || !roles.Contains(client.Role))
                    {
                        return 403;
                    }
                    else
                    {
                        return 200;
                    }
                }
            }
            catch (Exception ex)
            {
                return 500;
            }
        }
    }
}
