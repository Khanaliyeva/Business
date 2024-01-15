using AutoMapper;
using Business.Business.Exceptions;
using Business.Business.Services.Interfaces;
using Business.Business.ViewModels.AccountVM;
using Business.Core.Entity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Business.Services.Implimentations
{
    public class AccontService : IAccountService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccontService(UserManager<AppUser> userManager,IMapper mapper,RoleManager<IdentityRole> roleManager )
        {
            _userManager = userManager;
            _mapper = mapper;
            _roleManager = roleManager;
        }


        public Task<AppUser> Login(LoginVm loginVm)
        {
            var user = _userManager.FindByEmailAsync(loginVm.UsernameOrEmail);
            if( user == null)
            {
                user = _userManager.FindByNameAsync(loginVm.UsernameOrEmail);
                {
                    if( user != null)
                    {
                        throw new UserNotFounException();
                    }
                }
            }
            return user;
        }

        public async Task<AppUser> Register(RegisterVm registerVm)
        {
            AppUser newUser = _mapper.Map<AppUser>(registerVm);
            await _userManager.CreateAsync(newUser);
            return newUser;
        }













        //public async Task<AppUser> Register(UserRegisterVm registerVm)
        //{
        //    AppUser user = _mapper.Map<AppUser>(registerVm);
        //    await _userManager.CreateAsync(user, registerVm.Password);
        //    await _userManager.AddToRoleAsync(user, "Admin");
        //    return user;
        //}
        //public async Task CreateRole()
        //{
        //    foreach (var item in Enum.GetValues(typeof(UserRoles)))
        //    {
        //        if (!await _roleManager.RoleExistsAsync(item.ToString()))
        //        {
        //            await _roleManager.CreateAsync(new IdentityRole
        //            {
        //                Name = item.ToString()
        //            });
        //        }
        //    }
        //}
    }
}
