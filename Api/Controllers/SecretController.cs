using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api.Controllers
{
    public class SecretController : Controller
    {
        [Authorize]
        public string Index()
        {
            return "Secret message";
        }
    }
}
