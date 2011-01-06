using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using saf.Base;

namespace saf.Authorization
{
    public class IsPartialAccessExtension : IAccessExtension
    {
        public bool IsPartialEdit { get; set; }
        public bool IsPartialView { get; set; }
    }
}
