using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace TestGeneratorMvc.Controllers.ApiControllers
{
    [System.Web.Http.Authorize(Roles = "Admin")]
    public class UserController : ApiController
    {
        
    }
}
