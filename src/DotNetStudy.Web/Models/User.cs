using AuthorityManagement.Web.Models;
using System.Collections.Generic;

namespace DotNetStudy.Web.Models
{
    public class User
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
        public List<UserRole> UserRole { get; set; }
    }
}
