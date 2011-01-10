using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;

namespace safTests
{
    class TestUser : IPrincipal
    {
        public string[] Roles { get; set; }
        public bool IsInRole(string role)
        {
            return Roles.Contains(role);
        }

        public IIdentity Identity
        {
            get { return null; }
        }
    }
}
