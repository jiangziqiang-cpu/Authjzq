using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetStudy.Web.ViewModels.AccountViewModels
{
    public class UpdatePasswordModel
    {
        public string UserName { get; set; }

        [Required(ErrorMessage = "新密码不能为空")]
        public string NewPassword { get; set; }

        [Compare("NewPassword", ErrorMessage = "确认密码必须与新密码相同")]
        public string ConfirmNewPassword { get; set; }

    }
}
