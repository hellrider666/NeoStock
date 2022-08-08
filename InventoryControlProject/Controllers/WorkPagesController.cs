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
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InventoryControlProject.Controllers
{
    public class WorkPagesController : Controller
    {
        private readonly ILogger<WorkPagesController> _logger;
        private readonly IMapper _mapper;

        IClientService clientServ;
        ICompaniesService compSev;
        
        public WorkPagesController(ILogger<WorkPagesController> logger, IClientService serv, IMapper mapper, ICompaniesService compSev)
        {
            _logger = logger;
            clientServ = serv;
            _mapper = mapper;
            this.compSev = compSev;
        }
        [HttpGet]
        
        public JsonResult LoadProfileData(string login)
        {
            ProfileDTO user = clientServ.GetClient(login);
            var user_ = _mapper.Map<ProfileDTO, ProfileViewModel>(user);
            return Json(user_); 
        }
        public IActionResult StartWorkPages()
        {
            
            return View();
        }
        public IActionResult SelectCompanyPage()
        {

            IEnumerable<CompaniesTypesListDTO> typeDTO = compSev.GetAllCompaniesTypes();
            var compTypes = _mapper.Map<IEnumerable<CompaniesTypesListDTO>, List<CompaniesTypesListViewModel>>(typeDTO);
            //very very bad
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            foreach(var i in compTypes)
            {
                selectListItems.Add(new SelectListItem {Value = Convert.ToString(i.ID), Text = i.EnterpriseName});
            }
            //super very bad
            ViewBag.CompTypesSelect = selectListItems;

            IEnumerable<CompaniesDTO> compDTO = compSev.GetAllCompaniesByClientLogin(User.Identity.Name);
            var Companies = _mapper.Map<IEnumerable<CompaniesDTO>, List<CompaniesViewModel>>(compDTO);
            return View(Companies);
        }
        //public JsonResult LoadDropDowns()
        //{
            
        //}
    }
}
