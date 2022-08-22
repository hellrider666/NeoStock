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
using FormHelper;

namespace InventoryControlProject.Controllers
{
    public class WorkPagesController : Controller
    {
        private readonly ILogger<WorkPagesController> _logger;
        private readonly IMapper _mapper;
        static int CompanyId { get; set; }
        static int DepartId { get; set; }

        IClientService clientServ;
        ICompaniesService compSev;
        IDepartmentsService departServ;
        IProductionService prodServ;

        public WorkPagesController(ILogger<WorkPagesController> logger, IClientService serv, IMapper mapper, ICompaniesService compSev, IDepartmentsService departServ, IProductionService production)
        {
            _logger = logger;
            clientServ = serv;
            _mapper = mapper;
            this.compSev = compSev;
            this.departServ = departServ;
            prodServ = production;
        }
        [HttpGet]
        
        public JsonResult LoadProfileData(string login)
        {
            ProfileDTO user = clientServ.GetClient(login);
            var user_ = _mapper.Map<ProfileDTO, ProfileViewModel>(user);
            return Json(user_); 
        }
        public IActionResult StartWorkPages(int Id)
        {
            DepartId = Id;
            return View();
        }
        [HttpGet]
        public IActionResult ProductionListPartialView()
        {
            IEnumerable<ProductionListDTO> listDTOs = prodServ.GetProductionByDepartmentId(DepartId);
            var production = _mapper.Map<IEnumerable<ProductionListDTO>, List<ProductionListViewModel>> (listDTOs);
            return PartialView(production);
        }
        [HttpGet]
        public IActionResult CompaniesListPartialView()
        {
            IEnumerable<CompaniesDTO> compDTO = compSev.GetAllCompaniesByClientLogin(User.Identity.Name);
            var Companies = _mapper.Map<IEnumerable<CompaniesDTO>, List<CompaniesViewModel>>(compDTO);
            return PartialView(Companies);
        }
        [HttpGet]
        public IActionResult CreateProductPartialView()
        {
            return PartialView();
        }
        
        [HttpGet]
        public IActionResult DepartmentsListPartialView()
        {
            IEnumerable<DepartmentsListDTO> departList = departServ.GetAllDepartmentsByCompanyID(CompanyId);
            var Departments = _mapper.Map<IEnumerable<DepartmentsListDTO>, List<DepartmentsListViewModel>>(departList);
            return PartialView(Departments);
        }
        public IActionResult SelectDepartmentPage(int ID)
        {
            CompanyId = ID;
            IEnumerable<DepartTypesDTO> typeDTO = departServ.GetAllDepartsTypes();
            var departTypes =_mapper.Map<IEnumerable<DepartTypesDTO>, List<DepartTypeListViewModel>>(typeDTO);
            //also very bad
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            foreach(var i in departTypes)
            {
                selectListItems.Add(new SelectListItem { Value = Convert.ToString(i.Id), Text = i.TypeName });
            }
            ViewBag.DepartTypeSelect = selectListItems;
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
            
            ViewBag.CompTypesSelect = selectListItems;
            return View();
        }
        [HttpPost]
        public JsonResult CreateProduct(ProductionListViewModel product)
        {
            var product_ = _mapper.Map<ProductionListViewModel, ProductionListDTO>(product);
            product_.InsertDate = DateTime.Now;
            if(prodServ.CreateProduction(product_, DepartId) == true)
            {
                return Json(true);
            }

            return Json(false);
        }
        [HttpPost]
        public JsonResult CreateCompany(CreateCompanyViewModel model, int Id)
        {
            var company = _mapper.Map<CreateCompanyViewModel, CreateCompanyDTO>(model);
            if(compSev.CreateCompany(company, Id, User.Identity.Name) == true)
            {
                return Json(true);
            }
            else
            {
                return Json(false);
            }
        }
        public JsonResult CreateDepartment(CreateDepartmentViewModel model, int Id)
        {
            var depart = _mapper.Map<CreateDepartmentViewModel, CreateDepartmentDTO>(model);
            if (departServ.CreateDepartment(depart, Id, CompanyId) == true)
            {
                return Json(true);
            }
            else
            {
                return Json(false);
            }
        }
    }
}
