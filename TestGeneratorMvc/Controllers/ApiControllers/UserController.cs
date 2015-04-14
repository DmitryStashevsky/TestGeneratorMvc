using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using BusinessLayer.Interfaces;
using DataLayer.ApiModel;

namespace TestGeneratorMvc.Controllers.ApiControllers
{
    [System.Web.Http.Authorize(Roles = "Admin")]
    public class UserController : ApiController
    {
        private IUserService m_UserService;

        public UserController()
        {
            m_UserService = DependencyResolver.Current.GetService<IUserService>();
        }

        public List<ApiViewUserWithInfo> GetUsersWitnInfo()
        {
            return m_UserService.GetUsersWithInfo();
        }

        public int GetUsersCount()
        {
            return m_UserService.GetUsersCount();
        }
    }
}
