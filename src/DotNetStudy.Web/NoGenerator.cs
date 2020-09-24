using System;

namespace DotNetStudy.Web
{
    public static class NoGenerator
    {
        public static string New(string prefix)
        {
            return prefix + DateTime.Now.ToString("yyyyMMddHHmmssfff") + new Random().Next(100000, 999999);
        }
    }
}
