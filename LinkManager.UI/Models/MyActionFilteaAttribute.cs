using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace LinkManager.UI.Models
{
    public class MyActionFilterAttribute : IActionFilter
    {
        private Stopwatch _stopwatch = new Stopwatch();

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            _stopwatch.Stop();
            var elapsed = _stopwatch.Elapsed.ToString();

            string actionName = filterContext.ActionDescriptor.ActionName;
            string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;

            var ThreadId = Thread.CurrentThread.ManagedThreadId;

            string message = string.Format("[{0}] Finish execute Controller: {1}, Action: {2}, Executed time: {3}",
                ThreadId, controllerName, actionName, elapsed);
            SeriLogger.Info(message);
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            _stopwatch.Start();

            string actionName = filterContext.ActionDescriptor.ActionName;
            string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            var parameters = new Dictionary<string, object>(filterContext.ActionParameters);

            var ThreadId = Thread.CurrentThread.ManagedThreadId;

            string message = string.Format("[{0}] Start execute Controller: {1}, Action: {2}",
                ThreadId, controllerName, actionName) + " Parametes: {Parametes} ";
            
            SeriLogger.Info(message, MyDictionaryToJson(parameters));
        }

        string MyDictionaryToJson(Dictionary<string, object> dict)
        {
            var entries = dict.Select(d => String.Format("Parameter \"{0}\": {1}", d.Key, JsonConvert.SerializeObject(d.Value)));
            return string.Join(",", entries);
        }
    }
}