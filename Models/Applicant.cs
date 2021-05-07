using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeginClientAPI.Models
{
    public class Applicant
    {
        public int Id;
        public string SSN;
        public string FirstName;
        public string Middle_Initial;
        public string LastName;
        public string Suffix;
        public string Address1;
        public string Address2;
        public string City;
        public string State;
        public int Zip;
        public int ExtendedZip;
        public DateTime DateOfBirth;
        public string License_ID;
        public string Phone;
        public string Employer;
        public int YrsEmployed;
        public decimal Income;
        public int IncomePeriod;
        public decimal AdditionalIncome1;
        public int AdditionalIncomeSource1;
        public decimal AdditionalIncome2;
        public int AdditionalIncomeSource2;
        public bool DifferentMailingAddress;
        public string MailingAddress1;
        public string MailingAddress2;
        public string MailingAddress_City;
        public string MailingAddress_State;
        public int MailingAddress_Zip;
        public string Applicant_Email;
        public string Mortgage_Payment;
        public bool OwnRent;
        public decimal MortgageOrRent;
        public int YearsAtAddress;
        public bool HasAuthorizedCreditReport;
        public bool IsCitizen;
        public bool IsMilitary;
        public bool Bankruptcy;

    }
}