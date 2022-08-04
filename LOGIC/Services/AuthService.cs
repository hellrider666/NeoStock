using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using LOGIC.DTO;
using DAL.Entities;
using Microsoft.AspNetCore.Http;
using LOGIC.Interfaces;
using DAL.Interfaces;
using AutoMapper;

namespace LOGIC.Services
{
    public class AuthService : IAuthService
    {
        IUnitOfWork database { get; set; }        
        IHttpContextAccessor _httpContextAccessor { get; set; }

        public AuthService(IHttpContextAccessor _httpContextAccessor, IUnitOfWork uof)
        {
            this._httpContextAccessor = _httpContextAccessor;
            database = uof;
        }

        public bool Auth(AuthDTO user)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<AuthDTO, ClientIdentity>().ForMember(x=>x.Role, y=>y.MapFrom(z=>z.Role))).CreateMapper();
            var _user = mapper.Map<AuthDTO, ClientIdentity>(user);
            var currentUser = database.ClientIdentity.GetByString(_user.Login);
            if(currentUser != null)
            {
                Authenticate(currentUser);
                return true;
            }
            return false;
        }

        public void Authenticate(ClientIdentity user)
        {       
           var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.RoleName)
            };          
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);         
           _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public bool Logout()
        {
            try
            {
                _httpContextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                return true;
            }
            catch
            {

            }
            return false;
        }
    }
}
