using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Business.ViewModels.BlogVM
{
    public class CreateBlogVm
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile? File { get; set; }
    }
}
