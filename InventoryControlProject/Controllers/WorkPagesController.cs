using AutoMapper;
using LOGIC.DTO;
using LOGIC.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Helpers;
using InventoryControlProject.Models;

namespace InventoryControlProject.Controllers
{
    public class WorkPagesController : Controller
    {
        private readonly ILogger<WorkPagesController> _logger;
        private readonly IMapper _mapper;

        IClientService clientServ;

        public WorkPagesController(ILogger<WorkPagesController> logger, IClientService serv, IMapper mapper)
        {
            _logger = logger;
            clientServ = serv;
            _mapper = mapper;
        }
        [HttpGet]
        public JsonResult LoadProfileData(string login)
        {
            ProfileDTO user = clientServ.GetClient(login);
            var user_ = _mapper.Map<ProfileDTO, ProfileViewModel>(user);
            return Json(user_); 
        }
        public IActionResult StartWorkPage()
        {
            return View();
        }
    }
}
