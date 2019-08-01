using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace assessment_backEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PoliciesController : ControllerBase
    {
        [HttpGet("{name}")]
        public JsonResult Get(string name)
        {
            var policies = new Policies();

            return new JsonResult("value");
        }

        [HttpGet("{id}")]
        public JsonResult Get(Guid id)
        {
            return new JsonResult("value");
        }

    }
}