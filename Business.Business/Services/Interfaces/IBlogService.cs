
using Business.Business.ViewModels.BlogVM;
using Business.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Business.Services.Interfaces
{
    public interface IBlogService
    {
        Task<IQueryable> GetAll();
        Task Delete(int id);
        Task<Blog> GetById(int id);
        Task Update(UpdateBlogVm blogVm, string env);
        Task Create(CreateBlogVm blogVm, string env);
    }
}
