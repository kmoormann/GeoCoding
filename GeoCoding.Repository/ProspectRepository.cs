using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using GeoCoding.Model;
using Pariveda.Util;

namespace GeoCoding.Repository
{
    public interface IParivedaDevSchoolRepository<T>
    {
        T FillObject(IDataReader dataReader);
        IEnumerable<T> FillObjectCollection(IDataReader dataReader);
        void Update(T t);
    }

    public interface IProspectRepository
    {
        IEnumerable<Prospect> GetProspects();
        void Update(Prospect prospect);
    }

    public abstract class ProspectRepositoryBase : IProspectRepository
    {
        public virtual IEnumerable<Prospect> GetProspects()
        {
            throw new NotImplementedException();
        }
    

    public virtual void Update(Prospect prospect)
    {
 	    throw new NotImplementedException();
    }
}


    public class ProspectRepository : ProspectRepositoryBase, IParivedaDevSchoolRepository<Prospect>
    {
        public override IEnumerable<Prospect> GetProspects()
        {
            return GetList();
        }

        private IEnumerable<Prospect> GetList()
        {
            Database database = DatabaseFactory.CreateDatabase();
               using(IDataReader dataReader = database.ExecuteReader("GetProspects"))
            {
                return this.FillObjectCollection(dataReader);
            }
        }

        public Prospect FillObject(IDataReader dataReader)
        {
            Prospect prospect = new Prospect();

            //prospect.IDENTITY = DatabaseUtil.ToInt32(dataReader["IDENTITY"]);
            prospect.AccountNumber = DatabaseUtil.ToString(dataReader["AccountNumber"]);
            prospect.AccountType = DatabaseUtil.ToString(dataReader["AccountType"]);
            prospect.ProspectTitle = DatabaseUtil.ToString(dataReader["ProspectTitle"]);
            prospect.FirstName = DatabaseUtil.ToString(dataReader["FirstName"]);
            prospect.MiddleName = DatabaseUtil.ToString(dataReader["MiddleName"]);
            prospect.LastName = DatabaseUtil.ToString(dataReader["LastName"]);
            prospect.EmailAddress = DatabaseUtil.ToString(dataReader["EmailAddress"]);
            prospect.Phone = DatabaseUtil.ToString(dataReader["Phone"]);
            prospect.RawAddressLine1 = DatabaseUtil.ToString(dataReader["RawAddressLine1"]);
            prospect.RawAddressLine2 = DatabaseUtil.ToString(dataReader["RawAddressLine2"]);
            prospect.RawCity = DatabaseUtil.ToString(dataReader["RawCity"]);
            prospect.RawState = DatabaseUtil.ToString(dataReader["RawState"]);
            prospect.RawPostalCode = DatabaseUtil.ToString(dataReader["RawPostalCode"]);
            prospect.RawZip4 = DatabaseUtil.ToString(dataReader["RawZip4"]);
            prospect.RawCounty = DatabaseUtil.ToString(dataReader["RawCounty"]);
            prospect.RawCountry = DatabaseUtil.ToString(dataReader["RawCountry"]);
            prospect.CorrectedAddressLine1 = DatabaseUtil.ToString(dataReader["CorrectedAddressLine1"]);
            prospect.CorrectedAddressLine2 = DatabaseUtil.ToString(dataReader["CorrectedAddressLine2"]);
            prospect.CorrectedCity = DatabaseUtil.ToString(dataReader["CorrectedCity"]);
            prospect.CorrectedState = DatabaseUtil.ToString(dataReader["CorrectedState"]);
            prospect.CorrectedPostalCode = DatabaseUtil.ToString(dataReader["CorrectedPostalCode"]);
            prospect.CorrectedZip4 = DatabaseUtil.ToString(dataReader["CorrectedZip4"]);
            prospect.CorrectedCounty = DatabaseUtil.ToString(dataReader["CorrectedCounty"]);
            prospect.CorrectedCountry = DatabaseUtil.ToString(dataReader["CorrectedCountry"]);
            prospect.RawLongitude = DatabaseUtil.ToDouble(dataReader["RawLongitude"]);
            prospect.RawLatitude = DatabaseUtil.ToDouble(dataReader["RawLatitude"]);
            prospect.CorrectedLongitude = DatabaseUtil.ToDouble(dataReader["CorrectedLongitude"]);
            prospect.CorrectedLatitude = DatabaseUtil.ToDouble(dataReader["CorrectedLatitude"]);
            prospect.SourceSystem = DatabaseUtil.ToString(dataReader["SourceSystem"]);
            prospect.SourceSystemID = DatabaseUtil.ToString(dataReader["SourceSystemID"]);
            prospect.StateFIPS = DatabaseUtil.ToInt32(dataReader["StateFIPS"]);
            prospect.CityFIPS = DatabaseUtil.ToInt32(dataReader["CityFIPS"]);
            prospect.Place = DatabaseUtil.ToInt32(dataReader["Place"]);
            prospect.GNISID = DatabaseUtil.ToInt32(dataReader["GNISID"]);
            prospect.GNISIDPlaceName = DatabaseUtil.ToString(dataReader["GNISIDPlaceName"]);
            prospect.CISStatus = DatabaseUtil.ToString(dataReader["CISStatus"]);
            prospect.CurrentCustomerFlag = DatabaseUtil.ToInt32(dataReader["CurrentCustomerFlag"]);
            prospect.DoNotContactFlag = DatabaseUtil.ToInt32(dataReader["DoNotContactFlag"]);
            prospect.CancelledFlag = DatabaseUtil.ToInt32(dataReader["CancelledFlag"]);
            prospect.OptOutFlag = DatabaseUtil.ToInt32(dataReader["OptOutFlag"]);
            prospect.RejectedFlag = DatabaseUtil.ToInt32(dataReader["RejectedFlag"]);
            prospect.CompanyName = DatabaseUtil.ToString(dataReader["CompanyName"]);
            prospect.TERRCODE = DatabaseUtil.ToString(dataReader["TERRCODE"]);
            prospect.RowIsInferred = DatabaseUtil.ToString(dataReader["RowIsInferred"]);
            prospect.RowIsCurrent = DatabaseUtil.ToString(dataReader["RowIsCurrent"]);
            prospect.RowStartDate = DatabaseUtil.ToDateTime(dataReader["RowStartDate"]);
            prospect.RowEndDate = DatabaseUtil.ToDateTime(dataReader["RowEndDate"]);
            prospect.RowChangeReason = DatabaseUtil.ToString(dataReader["RowChangeReason"]);
            prospect.InsertAuditKey = DatabaseUtil.ToInt32(dataReader["InsertAuditKey"]);
            prospect.UpdateAuditKey = DatabaseUtil.ToInt32(dataReader["UpdateAuditKey"]);
            prospect.key = DatabaseUtil.ToInt32(dataReader["prospectKey"]);

            return prospect;
        }

        public IEnumerable<Prospect> FillObjectCollection(IDataReader dataReader)
        {
            List<Prospect> prospects = new List<Prospect>();
            while (dataReader.Read())
            {
                Prospect prospect = this.FillObject(dataReader);
                prospects.Add(prospect);
            }
            return prospects;
        }

        

        public override void Update(Prospect prospect)
        {
            try
            {

                //DatabaseFactory.CreateDatabase().ExecuteNonQuery(
                //    "UpdateProspect",
                //    prospect.CorrectedAddressLine1,
                //    prospect.CorrectedAddressLine2,
                //    prospect.CorrectedCity,
                //    prospect.CorrectedCountry,
                //    prospect.CorrectedCounty,
                //    prospect.CorrectedState,
                //    prospect.CorrectedZip4,
                //    prospect.CorrectedPostalCode,
                //    prospect.CorrectedLongitude,
                //    prospect.CorrectedLatitude,
                //    prospect.key,
                //    prospect.AccountNumber,
                //    prospect.AccountType,
                //    prospect.ProspectTitle,
                //    prospect.FirstName,
                //    prospect.LastName,
                //    prospect.MiddleName,
                //    prospect.EmailAddress,
                //    prospect.ProspectTitle,
                //    prospect.RawAddressLine1,
                //    prospect.RawAddressLine2,
                //    prospect.RawCity,
                //    prospect.RawState,
                //    prospect.RawZip4,
                //    prospect.RawCounty,
                //    prospect.RawCountry,
                //    prospect.RawLongitude,
                //    prospect.RawLatitude,
                //    prospect.SourceSystem,
                //    prospect.SourceSystemID,
                //    prospect.StateFIPS,
                //    prospect.CityFIPS,
                //    prospect.Place,
                //    prospect.GNISID,
                //    prospect.GNISIDPlaceName,
                //    prospect.CISStatus,
                //    prospect.CurrentCustomerFlag,
                //    prospect.DoNotContactFlag,
                //    prospect.CancelledFlag,
                //    prospect.OptOutFlag,
                //    prospect.RejectedFlag,
                //    prospect.CompanyName,
                //    prospect.TERRCODE,
                //    prospect.RowIsInferred,
                //    prospect.RowIsCurrent,
                //    //prospect.RowStartDate,
                //    //prospect.RowEndDate,
                //    prospect.RowChangeReason,
                //    prospect.InsertAuditKey,
                //    prospect.UpdateAuditKey


                //    );
            }
            catch (Exception ex)
            {
                        throw new ApplicationException("Error: ProspectUpdate", ex);
            }
            
        }



    }
}
