using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using assessment_backEnd.Security;
using BLL;
using DTO.enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace assessment_backEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PoliciesController : ControllerBase
    {
        /// <summary>
        /// Get the user linked to a policy number,only accessed by users with role admin
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetUserFromPolicy/{id}")]
        public ActionResult Get(Guid id)
        {
            try
            {
                string cookieValue = Request.Cookies["clientId"];
                var authorizeCode = Authorize.AuthorizeClient(cookieValue, eRoles.admin.ToString());
                if (authorizeCode < 200 || authorizeCode > 299)
                {
                    return StatusCode(authorizeCode);
                }
                else
                {
                    PolicyService pService = new PolicyService();
                    var clientDTO = pService.GetUserFromPolicy(id);
                    return StatusCode(200, clientDTO != null ? JsonConvert.SerializeObject(clientDTO) : "Client not found/ Error with Policy number");

                }
            }
            catch (Exception ex)
            {

                return StatusCode(500);
            }

        }

        /// <summary>
        /// Get list of policies linked to a user name, accessed by users with role admin
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("GetPoliciesFromUser/{name}")]
        public ActionResult Get(string name)
        {
            try
            {
                string cookieValue = Request.Cookies["clientId"];
                var authorizeCode = Authorize.AuthorizeClient(cookieValue, eRoles.admin.ToString());

                if (authorizeCode < 200 || authorizeCode > 299)
                {
                    return StatusCode(authorizeCode);
                }
                else
                {
                    PolicyService pService = new PolicyService();
                    var policyDTO = pService.GetPoliciesFromUser(name);

                    return StatusCode(200, policyDTO != null ? JsonConvert.SerializeObject(policyDTO) : "Policies not found");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }


        }
    }

}
