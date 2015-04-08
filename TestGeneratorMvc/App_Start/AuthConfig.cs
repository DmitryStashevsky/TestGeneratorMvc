using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using nonintanon.Security;

namespace TestGeneratorMvc.App_Start
{
    public static class AuthConfig
    {
        public static void RegisterAuth()
        {
            WebSecurity.InitializeDatabaseConnection("DefaultConnection", "User", "Id", "Name",
                autoCreateTables: true);
        }
    }
}