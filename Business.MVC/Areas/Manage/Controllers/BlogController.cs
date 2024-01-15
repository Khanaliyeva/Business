using AutoMapper;
using Business.Business.Services.Interfaces;
using Business.Business.ViewModels.BlogVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Business.MVC.Areas.Manage.Controllers
{

    [Area("Manage")]
    public class BlogController : Controller
    {
        private readonly IBlogService _service;
        private readonly IWebHostEnvironment _environment;
        private readonly IMapper _mapper;

        public BlogController(IBlogService service, IWebHostEnvironment environment, IMapper mapper)
        {
            _service = service;
            _environment = environment;
            _mapper = mapper;
        }


        //[Authorize("Admin, Moderator")]
        public async Task<IActionResult> Index()
        {
            var blogs = await _service.GetAll();
            return View(blogs);
        }




        [HttpGet]
        //[Authorize("Admin")]

        public IActionResult Create()
        {
            return View();
        }



        [HttpPost]
        //[Authorize("Admin")]
        public async Task<IActionResult> Create(CreateBlogVm blogVm)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var blog = _service.Create(blogVm, _environment.WebRootPath);
            return RedirectToAction("Index");
        }



        [HttpGet]
        //[Authorize("Admin")]
        public async Task<IActionResult> Update(int id)
        {
            var oldBlog = await _service.GetById(id);
            UpdateBlogVm blogVm = _mapper.Map<UpdateBlogVm>(oldBlog);
            return View(blogVm);
        }





        [HttpPost]
        //[Authorize("Admin")]
        public async Task<IActionResult> Update(UpdateBlogVm blogVm)
        {
            await _service.Update(blogVm, _environment.WebRootPath);
            return RedirectToAction("Index");
        }



        //[Authorize("Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
