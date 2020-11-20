using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QR.Data;
using QR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QR.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly UserContext _context;

        public UserController(
            ILogger<UserController> logger,
            UserContext context)
        {
            _logger = logger;
            _context = context;
        }

        private demouser GetLoggedUser(string username, string pw)
        {
            var user = _context.Demousers.FirstOrDefault(x => x.username == username && x.pw == pw);

            if(user != null)
            {
                return user;
            }
            return new demouser();
        }
        private User GetCurrUser(demouser u)
        {
            User user = new User();
            user.id = u.id;
            user.username = u.username;
            user.lastcheckedin = u.lastcheckedin;
            return user;
        }
        public IActionResult Login(string username, string pw)
        {
            var loggedUser = GetLoggedUser(username, pw);
            var user = GetCurrUser(loggedUser);
            return View(user);
        }
    }
}
