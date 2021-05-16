using System;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web.Http.Controllers;

namespace TIC.ClientAPI.ActionFilters
{
    public class HeaderAuthFilter : System.Web.Http.Filters.ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            string sessionToken = "";
            string useHeaderAuthorziation = "";
            try
            {
                useHeaderAuthorziation = ConfigurationManager.AppSettings.Get("UseHeaderAuth").ToString();
            }
            catch { useHeaderAuthorziation = "1"; }

            if (useHeaderAuthorziation == "0")
                return;

            try
            {
                sessionToken = actionContext.Request.Headers.GetValues("authentication").First();
                if (sessionToken == string.Empty)
                    throw new Exception("missing authentication");
            }
            catch (Exception)
            {
                actionContext.Response = new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest)
                {
                    Content = new StringContent("Missing authentication token in header")
                };
                return;
            }

            try
            {
                // try to convert string to Guid and trap error results.
                Guid g;
                var good = Guid.TryParse(sessionToken, out g);
                if (!good)
                    throw new Exception("Invalid session token");
            }
            catch (Exception)
            {
                actionContext.Response = new HttpResponseMessage(System.Net.HttpStatusCode.Forbidden)
                {
                    Content = new StringContent("Unable to validate session token")
                };
                return;
            }
        }
    }
}