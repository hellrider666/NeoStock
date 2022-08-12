using AutoMapper;
using InventoryControlProject.Models;
using LOGIC.DTO;
using LOGIC.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace InventoryControlProject.Controllers
{
    public class AuthController : Controller
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IMapper _mapper;

        IAuthService auth;

        public AuthController(ILogger<AuthController> logger, IAuthService serv, IMapper mapper)
        {
            _logger = logger;
            auth = serv;
            _mapper = mapper;
        }
        public IActionResult AuthPage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AuthPage(AuthViewModel user)
        {            
                var _user = _mapper.Map<AuthViewModel, AuthDTO>(user);
                bool check = auth.Auth(_user);
                if (check == true)
                {
                    return Redirect("/WorkPages/SelectCompanyPage");
                }
                return View();                                
        }
      
        public RedirectResult Logout()
        {
            if(auth.Logout() == true)
            {
                return Redirect("/Home/Index");
            }
            return Redirect("/WorkPages/StartWorkPages");
        }
    }
}
