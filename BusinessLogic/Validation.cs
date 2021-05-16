using TIC.ClientAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TIC.ClientAPI.BusinessLogic
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

        public static Dictionary<int, string> Applicant(Applicant[] applicant)
        {
            var result = new Dictionary<int, string>();

            if (applicant.Count(m => m.SortOrder == 1) > 1)
                result.Add(1, "More than one applicant");

            if (applicant.Count(m => m.FirstName == "JimBob") > 0)
                result.Add(2, "We do not accept applicants named JimBob");

            return result;
        }
    }
}