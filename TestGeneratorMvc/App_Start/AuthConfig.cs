using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using nonintanon.Security;

namespace TestGeneratorMvc.App_Start
{
    public static class AuthConfig
    {
        public static void RegisterAuth()
        {
            WebSecurity.InitializeDatabaseConnection("DefaultConnection", "User", "Id", "UserName",
                autoCreateTables: true);

            if (!Roles.RoleExists("User"))
            {
                Roles.CreateRole("User");
            }
            if (!Roles.RoleExists("Trainer"))
            {
                Roles.CreateRole("Trainer");
            }
            if (!Roles.RoleExists("Admin"))
            {
                Roles.CreateRole("Admin");
            }
            if (!WebSecurity.UserExists("MainAdmin"))
            {
                WebSecurity.CreateUserAndAccount("MainAdmin", "password", new { Id = Guid.NewGuid() });
                Roles.AddUserToRole("MainAdmin", "Admin");
            }
        }
    }
}