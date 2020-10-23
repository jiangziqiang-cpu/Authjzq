
using AuthorityManagement.Web.Models;
using System.Collections.Generic;

namespace Poseidon.Web.Areas.Admin
{
    public class Pages
    {
        public const string Administration = "Administration";

        public const string Dashboard = "Administration.Dashboard";

        public const string Authorization = "Administration.Authorization";

        public const string Authorization_Organization = "Administration.Authorization.Organization";
        public const string Authorization_Organization_Create = "Administration.Authorization.Organization.Create";
        public const string Authorization_Organization_Edit = "Administration.Authorization.Organization.Edit";
        public const string Authorization_Organization_Delete = "Administration.Authorization.Organization.Delete";
        public const string Authorization_Organization_User = "Administration.Authorization.Organization.User";

         

        public const string Authorization_Role = "Administration.Authorization.Role";
        public const string Authorization_Role_Create = "Administration.Authorization.Role.Create";
        public const string Authorization_Role_Edit = "Administration.Authorization.Role.Edit";
        public const string Authorization_Role_Delete = "Administration.Authorization.Role.Delete";

        public const string Authorization_User = "Administration.Authorization.User";
        public const string Authorization_User_Create = "Administration.Authorization.User.Create";
        public const string Authorization_User_Edit = "Administration.Authorization.User.Edit";
        public const string Authorization_User_Delete = "Administration.Authorization.User.Delete";


        public const string Commodity = "Administration.Commodity";
        public const string Commodity_Create = "Administration.Commodity.Create";
        public const string Commodity_Edit = "Administration.Commodity.Edit";
        public const string Commodity_Delete = "Administration.Commodity.Delete";

        public const string Category = "Administration.Category";
        public const string Category_Create = "Administration.Category.Create";
        public const string Category_Edit = "Administration.Category.Edit";
        public const string Category_Delete = "Administration.Category.Delete";


        public const string Trade = "Administration.Trade";
        public const string Order = "Administration.Order";


        public const string Expense = "Administration.Expense";
        public const string Expense_Create = "Administration.Expense.Create";
        public const string Expense_Edit = "Administration.Expense.Edit";
        public const string Expense_Delete = "Administration.Expense.Delete";

        public const string Distribution = "Administration.Distribution";
        public const string Distribution_Create = "Administration.Distribution.Create";
        public const string Distribution_Edit = "Administration.Distribution.Edit";
        public const string Distribution_Delete = "Administration.Distribution.Delete";

        public const string Configuration = "Administration.Configuration";
        public const string Configuration_Dictionary = "Administration.Configuration.Dictionary";
        public const string Configuration_Dictionary_Create = "Administration.Configuration.Dictionary.Create";
        public const string Configuration_Dictionary_Edit = "Administration.Configuration.Dictionary.Edit";
        public const string Configuration_Dictionary_Delete = "Administration.Configuration.Dictionary.Delete";

        public IEnumerable<RoleFictitious> GetPermissions()
        {
            var authorization = new RoleFictitious(Pages.Authorization, "授权管理");
            var organizations = authorization.AddChild(Pages.Authorization_Organization, "门店管理", "拥有门店的管理权限。");
            organizations.AddChild(Pages.Authorization_Organization_Create, "创建门店");
            organizations.AddChild(Pages.Authorization_Organization_Edit, "编辑门店");
            organizations.AddChild(Pages.Authorization_Organization_Delete, "删除门店");
            organizations.AddChild(Pages.Authorization_Organization_User, "门店店员管理");
            var roles = authorization.AddChild(Pages.Authorization_Role, "角色管理", "拥有角色的管理权限。");
            roles.AddChild(Pages.Authorization_Role_Create, "创建角色");
            roles.AddChild(Pages.Authorization_Role_Edit, "编辑角色");
            roles.AddChild(Pages.Authorization_Role_Delete, "删除角色");

            var users = authorization.AddChild(Pages.Authorization_User, "用户管理", "拥有管理用户的权限。");
            users.AddChild(Pages.Authorization_User_Create, "创建用户");
            users.AddChild(Pages.Authorization_User_Edit, "编辑用户");
            users.AddChild(Pages.Authorization_User_Delete, "删除用户");
            return new[] {           
            authorization,           
            };
        }

        public IEnumerable<RoleNavigation> GetNavigations()
        {
            var dashboard = new RoleNavigation("工作台", "/Admin", "fas fa-tachometer-alt");
            var commodity = new RoleNavigation("商品管理", "/Admin/Commodity/List", "fas fa-hashtag", Pages.Commodity);
            var category = new RoleNavigation("分类管理", "/Admin/Category/List", "fas fa-lemon", Pages.Category);
            var trade = new RoleNavigation("交易单", "/Admin/Trade/List", "fas fa-dollar-sign", Pages.Trade);
            var order = new RoleNavigation("订单管理", "/Admin/Order/List", "fas fa-shopping-bag", Pages.Order);
            var expense = new RoleNavigation("日常支出", "/Admin/Expense/List", "fas fa-comments-dollar", Pages.Expense);
            var distribution = new RoleNavigation("利润分成", "/Admin/Distribution/List", "fas fa-wallet ", Pages.Distribution);
            var configuration = new RoleNavigation("系统配置", string.Empty, "fas fa-cogs", Pages.Configuration);
            configuration.AddChild("数据字典", "/Admin/Dictionary/List", "fas fa-book", Pages.Configuration_Dictionary);


            var authorization = new RoleNavigation("授权管理", string.Empty, "fas fa-shield-alt", Pages.Authorization);
            authorization.AddChild("门店管理", "/Admin/Organization/List", "fas fa-cubes", Pages.Authorization_Organization);
            authorization.AddChild("角色管理", "/RoleManageMent/ShowRole", "fas fa-user-secret", Pages.Authorization_Role);
            authorization.AddChild("用户管理", "/User/ShowAllUser", "fas fa-users", Pages.Authorization_User);

            return new[]
            {
                dashboard,
                commodity,
                category,
                trade,
                order,
                expense,
                distribution,
                authorization,
                configuration
                };
        }
    }
}
