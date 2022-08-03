using AutoMapper;
using LOGIC.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryControlProject.Models;
using LOGIC.DTO;

namespace InventoryControlProject.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly ILogger<RegistrationController> _logger;
        private readonly IMapper _mapper;

        IRegistrationService regService;

        public RegistrationController(ILogger<RegistrationController> logger, IRegistrationService serv, IMapper mapper)
        {
            _logger = logger;
            regService = serv;
            _mapper = mapper;
        }
        public IActionResult RegistrationPage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult RegistrationPage(RegistrationViewModel client)
        {
            try
            {               
                var _client = _mapper.Map<RegistrationViewModel, RegistrationDTO>(client);
                bool check = regService.CreateUser(_client);
                if(check == true) 
                {
                    return Redirect("/Home/Index");
                }
                                
            }
            catch
            {
                //обработчик ошибок Тут быть должен
            }
            return View();
        }
        
    }
}
