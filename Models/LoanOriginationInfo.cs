using System;

namespace TIC.ClientAPI.Models
{
    public class LoanOriginationInfo
    {
        public bool IsApplicant;
        public string FirstName;
        public string LastName;
        public int Id;
        public string Address1;
        public string Address2;
        public string City;
        public string State;
        public int Zip;
        public int ExtendedZip;
        public DateTime DateOfBirth;
    }
}