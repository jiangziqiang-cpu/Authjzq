using DotNetStudy.Web.Models;
using DotNetStudy.Web.ViewModels.MyOrdersModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorityManagement.Web.ViewModels.AccountViewModels
{
    public class AccountViewModels
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public char Sex { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Avator { get; set; }
        public int EmailConfirmed { get; set; }
        public int Active { get; set; }

        public List<User> Users{ get; set; }

        public List<string> Roles { get; set; }
        public List<string> SelectedRoles { get; set; }

    }

    public class UserViewModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public char Sex { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public int EmailConfirmed { get; set; }
        public int Active { get; set; }

    }
}
