using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Principal;

namespace saf.Base
{
    public interface IPrincipalProvider
    {
        public IPrincipal GetCurrentPrincipal();
    }
}
