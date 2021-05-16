using TIC.ClientAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TIC.ClientAPI.BusinessLogic
{
    public static class DataAccess
    {
        public static int WriteLoanOriginationInfo(LoanOriginationInfo[] loanOriginationInfo)
        {
            return 1;
        }

        public static int WriteApplicant(Applicant[] applicant)
        {
            try
            {
                // System.Threading.Tasks.Task<HttpResponseMessage> response;
                // var contentString = response.Result.Content.ReadAsStringAsync().Result;

            }
            catch
            {

            }
            finally
            {

            }
            
            return 1;
        }
    }
}