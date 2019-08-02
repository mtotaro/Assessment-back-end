using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
    public class UsersController : ControllerBase
    {
        [HttpGet("GetById/{id}")]
        public ActionResult Get(Guid id)
        {
            try
            {
                string cookieValue = Request.Cookies["clientId"];
                var authorizeCode = Authorize.AuthorizeClient(cookieValue, eRoles.admin.ToString(), eRoles.user.ToString());
                if (authorizeCode < 200 || authorizeCode > 299)
                {
                    return StatusCode(authorizeCode);
                }
                else
                {
                    ClientService clService = new ClientService();
                    var clientDTO = clService.GetById(id);
                    return StatusCode(200, clientDTO != null ? JsonConvert.SerializeObject(clientDTO) : "Client not found");

                }
            }
            catch (Exception ex)
            {

                return StatusCode(500);
            }
                     
                       
        }

        [HttpGet("GetByName/{name}")]
        public ActionResult Get(string name)
        {
            try
            {
                string cookieValue = Request.Cookies["clientId"];
                var authorizeCode = Authorize.AuthorizeClient(cookieValue, eRoles.admin.ToString(), eRoles.user.ToString());

                if(authorizeCode < 200 || authorizeCode > 299)
                {
                    return StatusCode(authorizeCode);
                }
                else
                {
                    ClientService clService = new ClientService();
                    var clientDTO = clService.GetByName(name);

                    return StatusCode(200, clientDTO != null ? JsonConvert.SerializeObject(clientDTO) : "Client not found");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }


        }
    }
}