using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Poseidon.Infrastructure.Alarms
{
    public class AlertFilter : IActionFilter, IAsyncResultFilter
    {
        public const string CookiePrefix = "ZEUS.ALARM";
        private readonly IAlarm _alarm;
        private AlertEntry[] _existingEntries = Array.Empty<AlertEntry>();
        private bool _shouldDeleteCookie;
        public AlertFilter(
            IAlarm alarm)
        {
            _alarm = alarm;
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // �ж��Ƿ������Ϣʱ
            var messages = Convert.ToString(filterContext.HttpContext.Request.Cookies[CookiePrefix]);
            if (string.IsNullOrEmpty(messages))
                return;
            // ����Ϣ����ʱ��ȡ����Ϣʵ��
            var messageEntries = JsonConvert.DeserializeObject<AlertEntry[]>(messages);
            // ��ת������Ϣʵ�岻����ʱ������ɾ������
            if (messageEntries == null || messageEntries.Length == 0)
            {
                _shouldDeleteCookie = true;
                return;
            }
            _existingEntries = messageEntries;
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var messageEntries = _alarm.List().ToArray();

            if (messageEntries.Length == 0 && _existingEntries.Length == 0)
                return;

            _existingEntries = messageEntries.Concat(_existingEntries).ToArray();
            if (!(filterContext.Result is ViewResult || filterContext.Result is PageResult) && _existingEntries.Length > 0)
            {
                filterContext.HttpContext.Response.Cookies.Append(CookiePrefix, JsonConvert.SerializeObject(_existingEntries), new CookieOptions { HttpOnly = true });
            }
        }

        public async Task OnResultExecutionAsync(ResultExecutingContext filterContext, ResultExecutionDelegate next)
        {
            if (_shouldDeleteCookie)
            {
                DeleteCookies(filterContext);
                await next();
                return;
            }

            if (!(filterContext.Result is ViewResult || filterContext.Result is PageResult))
            {
                await next();
                return;
            }

            if (_existingEntries.Length == 0)
            {
                await next();
                return;
            } 
            //�����֪ͨд�뵽ViewBag��
            ((Controller)filterContext.Controller).ViewBag.AlertEntries = _existingEntries;
            //�����Ϣ
            DeleteCookies(filterContext);

            await next();
        }

        private void DeleteCookies(ResultExecutingContext filterContext)
        {
            filterContext.HttpContext.Response.Cookies.Delete(CookiePrefix);
        }
         
    }
}
