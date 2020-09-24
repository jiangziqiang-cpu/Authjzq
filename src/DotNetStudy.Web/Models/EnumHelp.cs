using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace DotNetStudy.Web.ViewModels.MyOrdersModels
{
    public static class EnumHelp
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
    }
}
