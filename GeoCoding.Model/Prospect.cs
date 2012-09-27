using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeoCoding.Model
{
    // this class replaced the address class and represents a prospect customer
    public class Prospect
    {
        public int? IDENTITY { get; set; }
        public int? key { get; set; }
        public string AccountNumber { get; set; }
        public string AccountType { get; set; }
        public string ProspectTitle { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Phone { get; set; }
        public string RawAddressLine1 { get; set; }
        public string RawAddressLine2 { get; set; }
        public string RawCity { get; set; }
        public string RawState { get; set; }
        public string RawPostalCode { get; set; }
        public string RawZip4 { get; set; }
        public string RawCounty { get; set; }
        public string RawCountry { get; set; }
        public string CorrectedAddressLine1 { get; set; }
        public string CorrectedAddressLine2 { get; set; }
        public string CorrectedCity { get; set; }
        public string CorrectedState { get; set; }
        public string CorrectedPostalCode { get; set; }
        public string CorrectedZip4 { get; set; }
        public string CorrectedCounty { get; set; }
        public string CorrectedCountry { get; set; }
        public double RawLongitude { get; set; }
        public double RawLatitude { get; set; }
        public double CorrectedLongitude { get; set; }
        public double CorrectedLatitude { get; set; }
        public string SourceSystem { get; set; }
        public string SourceSystemID { get; set; }
        public int StateFIPS { get; set; }
        public int CityFIPS { get; set; }
        public int Place { get; set; }
        public int GNISID { get; set; }
        public string GNISIDPlaceName { get; set; }
        public string CISStatus { get; set; }
        public int CurrentCustomerFlag { get; set; }
        public int DoNotContactFlag { get; set; }
        public int CancelledFlag { get; set; }
        public int OptOutFlag { get; set; }
        public int RejectedFlag { get; set; }
        public string CompanyName { get; set; }
        public string TERRCODE { get; set; }
        public string RowIsInferred { get; set; }
        public string RowIsCurrent { get; set; }
        public DateTime RowStartDate { get; set; }
        public DateTime RowEndDate { get; set; }
        public string RowChangeReason { get; set; }
        public int InsertAuditKey { get; set; }
        public int UpdateAuditKey { get; set; }
    }
}
