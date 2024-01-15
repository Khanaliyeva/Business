using AutoMapper;
using Business.Business.ViewModels.AccountVM;
using Business.Business.ViewModels.BlogVM;
using Business.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Business
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<CreateBlogVm, Blog>();
            CreateMap<CreateBlogVm, Blog>().ReverseMap();
            CreateMap<UpdateBlogVm, Blog>();
            CreateMap<UpdateBlogVm, Blog>().ReverseMap();
            CreateMap<LoginVm, AppUser>();
            CreateMap<LoginVm, AppUser>().ReverseMap();
            CreateMap<RegisterVm, AppUser>();
            CreateMap<RegisterVm, AppUser>().ReverseMap();
        }
    }
}
