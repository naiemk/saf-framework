using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using saf.Attributes;
using saf.Base;

namespace safTests
{

    [Grant(Order = 1, Roles = new[] { "Everyone" }, Permission = Permission.View)]
    [Grant(Order = 2, Roles = new[] { "QLDAdmin", "NSWAdmin" }, Permission = Permission.View | Permission.Edit | Permission.Create)]
    [Grant(Order = 3, Roles = new[] { "Deleter" }, Permission = Permission.Delete)]
    [Grant(Order = 4, Roles = new[] { "God" }, Permission = Permission.View | Permission.Own)]
    [Deny(Order = 5, Roles = new[] { "NSWAdmin" }, Permission = Permission.Edit)]
    [AuthorizationCustom(Order = 6, CustomType = typeof(TestObject), Method = "OnlyQld")]
    public class TestObject
    {
        [Grant(Roles = new[] { "Everyone" }, Permission = Permission.View)]
        [Deny(Roles = new[] { "God" }, Permission = Permission.View)]
        public int YouCanSeeMe { get; set; }

        [Grant(Roles = new[] { "Everyone" }, Permission = Permission.Edit)]
        [Deny(Roles = new[] { "God" }, Permission = Permission.Edit | Permission.View)]
        public string YouCanEditMe { get; set; }

        [Deny(Roles = new[] { "Everyone" }, Permission = Permission.View)]
        public string YouCanNotSeeMe { get; set; }

        [Deny(Roles = new[] { "Everyone" }, Permission = Permission.Edit)]
        public string YouCanSeeMeButNotEditMe { get; set; }

        [Grant(Roles = new[] { "*" }, Permission = Permission.View)]
        [Deny(Roles = new[] { "QLDMan" }, Permission = Permission.All)]
        public string EverybodyCanSeeMe { get; set; }


        public string[] States { get; set; }

        public static Permission? OnlyQld(IPrincipal pri, object instance)
        {
            var user = pri as TestUser;
            if (user.Roles.Any(r => r.Contains("QLD"))
                &&
                (((TestObject)instance).States != null && ((TestObject)instance).States.Contains("QLD"))
                )
                return Permission.All;
            return null;
        }
    }
}
