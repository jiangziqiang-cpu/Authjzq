using System.ComponentModel.DataAnnotations;

namespace DotNetStudy.Web.ViewModels.AccountViewModels
{
    public class RegisterModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "用户名不能为空")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "密码不能为空")]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "确认密码必须与密码相同")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "性别不能为空")]
        public char Sex { get; set; }
        [Required(ErrorMessage = "年龄不能为空")]
        public int Age { get; set; }
        [EmailAddress(ErrorMessage = "邮箱格式错误")]
        public string Email { get; set; }
        [Required(ErrorMessage = "电话号码不能为空")]
        public string Phone { get; set; }
    }
}
