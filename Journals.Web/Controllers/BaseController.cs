using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Journals.Web.Controllers
{
    public class BaseController : Controller
    {
        public int GetUserId() {
            var identity = (ClaimsIdentity)User.Identity;

            // Get the claims values

            var sid = Convert.ToInt32( identity.Claims.Where(c => c.Type == ClaimTypes.Sid)
                               .Select(c => c.Value).SingleOrDefault());
            return sid;
        }
    }
}
