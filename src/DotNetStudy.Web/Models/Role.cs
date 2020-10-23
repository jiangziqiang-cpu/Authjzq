using AuthorityManagement.Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetStudy.Web.ViewModels.MyOrdersModels
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string DisPlayName { get; set; }

        public string Description { get; set; }
        public RoleEnum Active { get; set; }

        public List<RoleClaims> RoleClaims { get; set; }
    }

    public enum RoleEnum
    {
        [Display(Name = "启用")]
        启用 =1,
        [Display(Name = "禁用")]
        禁用 =0
    }
}
