using AutoMapper;
using DAL.DataContext;
using InventoryControlProject.Models;
using LOGIC.DTO;
using LOGIC.Interfaces;
using LOGIC.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;


namespace InventoryControlProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
       
        
        
        
        public HomeController(ILogger<HomeController> logger, IClientService serv, IMapper mapper)
        {
            _logger = logger;
            
           
        }

        public IActionResult Index()
        {
            if(User.Identity.IsAuthenticated)
            {
                if(User.IsInRole("Предприниматель"))
                {
                    return Redirect("/WorkPages/SelectCompanyPage");
                }
                else
                {
                    return Redirect("/WorkPages/StartWorkPages");
                }              
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
