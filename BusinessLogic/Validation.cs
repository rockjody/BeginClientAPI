using BeginClientAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeginClientAPI.BusinessLogic
{
    public static class Validation
    {
        public static Dictionary<int, string> LoanOriginationInfo(LoanOriginationInfo[] loanOriginationInfo)
        {
            var result = new Dictionary<int, string>();

            if (loanOriginationInfo.Count(m => m.IsApplicant == true) > 1)
                result.Add(1, "More than one applicant");

            if (loanOriginationInfo.Count(m => m.FirstName == "JimBob") > 0)
                result.Add(2, "We do not accept applicants named JimBob");

            return result;
        }
    }
}