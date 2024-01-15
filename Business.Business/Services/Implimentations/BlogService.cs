using Business.Business.Services.Interfaces;
using Business.Business.ViewModels.BlogVM;
using Business.Core.Entity;
using Business.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Business.Services.Implimentations
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _repo;

        public BlogService(IBlogRepository repo)
        {
            _repo = repo;
        }

        public async Task Create(CreateBlogVm blogVm,string env)
        {
            Blog blog = new Blog()
            {
                Title=blogVm.Title,
                Description=blogVm.Description,
            };
            await _repo.Create(blog);
            await _repo.SaveChanges();
            
        }

        public async Task Delete(int id)
        {
            await _repo.Delete(id);
            await _repo.SaveChanges();
        }

        public async Task<IQueryable> GetAll()
        {
            IQueryable<Blog> query = await _repo.GetAllAsync();
            return query;
        }

        public async Task<Blog> GetById(int id)
        {
            return await _repo.GetById(id);
        }

        public async  Task Update(UpdateBlogVm blogVm,string env)
        {
            Blog blog = await _repo.GetById(blogVm.Id);
            blog.Description=blogVm.Description;
            blog.Title=blogVm.Title;
            await _repo.Update(blog);
            await _repo.SaveChanges();
        }
    }
}
