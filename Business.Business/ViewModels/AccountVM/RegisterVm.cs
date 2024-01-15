using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Business.ViewModels.AccountVM
{
    public class RegisterVm
    {
        [Required]
        [MaxLength(50)]
        [MinLength(10)]
        public string Name { get; set; }



        [Required]
        [MaxLength(50)]
        [MinLength(10)]
        public string Surname { get; set; }



        [Required]
        [MaxLength(50)]
        [MinLength(10)]
        public string UserName { get; set; }


        [Required]
        [MaxLength(50)]
        [MinLength(20)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Required]
        [MaxLength(18)]
        [MinLength(6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Required]
        [DataType(DataType.Password), Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
