using Business.Business.ViewModels.AccountVM;
using Business.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Business.Services.Interfaces
{
    public interface IAccountService
    {
        Task<AppUser> Login(LoginVm loginVm);
        Task<AppUser>  Register(RegisterVm registerVm);
    }
}
