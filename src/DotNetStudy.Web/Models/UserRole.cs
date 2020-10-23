using DotNetStudy.Web.Models;
using DotNetStudy.Web.ViewModels.MyOrdersModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorityManagement.Web.Models
{
    public class UserRole
    {
        public int Id { get; set; }
        /// <summary>
        /// 用户Id
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// RoleId
        /// </summary>
        public int RoleId { get; set; }

        public User User { get; set; }
    }
}
