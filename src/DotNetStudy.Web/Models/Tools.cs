using AuthorityManagement.Web.Models;
using DotNetStudy.Web.Controllers;
using DotNetStudy.Web.Models;
using Poseidon.Web.Areas.Admin;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DotNetStudy.Web.ViewModels.MyOrdersModels
{
    public static class Tools
    {
        /// <summary>
        /// 枚举特性获取名称
        /// </summary>
        /// <param name="value">枚举名称</param>
        /// <returns></returns>
        public static string GetDescription(this object value)
        {
            var type = value.GetType();
            var name = Enum.GetName(type,value);
            if (!string.IsNullOrEmpty(name))
            {
                FieldInfo fieldInfo = type.GetField(name);
                DisplayAttribute displayAttribute = fieldInfo.GetCustomAttribute<DisplayAttribute>();
                if (displayAttribute != null)
                {
                    return displayAttribute.Name;
                }
            }
            return string.Empty;
        
        }
        /// <summary>
        /// 判断字符串是否为空
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }
        public static string Format(this string str, params string[] param)
        {
            if (param != null)
                foreach (var p in param)
                    str = string.Format(str, p);
            return str;
        }

        /// <summary>
        /// 比较两个路径的值是否相同
        /// </summary>
        /// <param name="str">左值</param>
        /// <param name="target">右值</param>
        /// <param name="hierarchy">需要比较的前几个层级，以/分层。</param>
        /// <returns></returns>
        public static bool ComparePath(this string str, string target, int hierarchy)
        {
            if (hierarchy <= 0)
                throw new ArgumentNullException(nameof(hierarchy));

            if (string.IsNullOrEmpty(str) || string.IsNullOrEmpty(target))
                return str == target;

            return GetHierarchyPath(str, hierarchy) == GetHierarchyPath(target, hierarchy);
        }
        private static string GetHierarchyPath(string path, int hierarchy)
        {
            var values = path.Split("/", StringSplitOptions.RemoveEmptyEntries);
            if (values.Length < hierarchy)
                hierarchy = values.Length;
            StringBuilder hierarchyStr = new StringBuilder();
            for (int i = 0; i < hierarchy; i++)
            {
                hierarchyStr.Append(values[i]);
            }
            return hierarchyStr.ToString();
        }


        /// <summary>
        /// 密码加密
        /// </summary>
        /// <param name="myString"></param>
        /// <returns></returns>
        public static string GetMD5(string myString)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = System.Text.Encoding.Unicode.GetBytes(myString);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x");
            }
            return byte2String;
        }

        /// <summary>
        /// 判断按钮是否有权限
        /// </summary>
        /// <param name="User"></param>
        /// <param name="PermissionName"></param>
        /// <returns></returns>
        public static bool IsHasClaims(ClaimsPrincipal User,string PermissionName)
        {
           return User.HasClaim(Poseidon.Infrastructure.AppConstants.RoleClaims, PermissionName);
        }

        public static IEnumerable<RoleNavigation> GetNavigations
        {
            get
            {
                Pages page = new Pages();
                return page.GetNavigations();
            }
        }
    }
}
