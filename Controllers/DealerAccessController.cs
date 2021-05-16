using System;
using System.Collections.Generic;
using System.Linq;
using TimeLib;
using System.Web.Http;
using System.Reflection;
using System.Configuration;
using TimeErrorLib;
using TIC.ClientAPI.ActionFilters;

namespace TIC.ClientAPI.Controllers
{
    public class DealerAccessController : ApiController
    {
        /// <summary>
        /// Authenticate a user login request within the scope of the Dealer. This provides authorized credential token for relative API requests
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HeaderAuthFilter]
        [HttpPost]
        [ActionName("Auth")]
        public VendorAccessResponse Auth(VendorAccessRequest request)
        {
            string METHOD_NAME = MethodBase.GetCurrentMethod().Name;

            //var authToken = false;

            var headValue_authGuid = string.Empty;
            IEnumerable<string> headerValues;

            if (Request.Headers.TryGetValues("authentication", out headerValues))
            {
                headValue_authGuid = headerValues.FirstOrDefault();
            }

            // -New way
            VendorAccessResponse response = new VendorAccessResponse();
            try
            {
                // First we need to validate the credentials.
                response = request.ProcessVendorAuthentication(headValue_authGuid);

                if (response.Success)
                {
                    // Validate this object and combine with componant 
                    request.Success = request.ValidateMe();
                    if (!request.Success)
                    {
                        if (response.Error.ErrorDetail.Length.Equals(0) && request.Errors.Count > 0)
                            response.Error = request.Errors[0];
                        //response.Errors.AddRange(request.Errors);
                    }
                    else
                    {
                        bool isAuthPassDcpt = ConfigurationManager.AppSettings.Get(SPNames.WC_SECURITY_AuthPasswordDecrypt) == "1";
                        //Secondary we validate the dealer login
                        response = request.ProcessLoginRequest(isAuthPassDcpt);

                        // Finally we generate the Login Token record
                        if (response.Success)
                        {
                            response = request.ProcessTokenResult();
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                request.Success = false;
                response.Error = new ErrorObject(this.GetType().ToString(), METHOD_NAME, 1,
                    "POST ERROR", "A critical error occurred during the post of this request.", ex.Message);
                //response.Errors.Add(new ErrorObject(this.GetType().ToString(), METHOD_NAME, 1,
                //    "POST ERROR", "A critical error occurred during the post of this request.", ex.Message));
            }

            response.Success = request.Success && response.Success;
            // Add API Event item - DEAN 10-22-2019  ...needs GetVender() like request.Cred..Token
            bool isActiveHistoryLogAuth = ConfigurationManager.AppSettings.Get(SPNames.WC_SECURITY_WriteEventHistoryAuthenticate) == "1";
            if (isActiveHistoryLogAuth)
            {
                long _orderId = -1;
                DBHelper.SaveVendorEventLog(request.GetVendor(), request.AccessLogin.UserName,
                    this.GetType().ToString(), METHOD_NAME, _orderId, response.Success,
                    DBHelper.makeJSon(request), DBHelper.makeJSon(response), Request.GetClientIpString());
            }

            return response;

        }
    }
}