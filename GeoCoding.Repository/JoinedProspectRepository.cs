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
    public class JoinedProspectRepository
    {
        public List<JoinedProspect> GetList()
        {
            Database database = DatabaseFactory.CreateDatabase();
            // joins the prospect table with the table of company boundries and returns the matches
            using (IDataReader dataReader = database.ExecuteReader("JoinTables"))
            {
                return this.FillObjectCollection(dataReader);
            }
        }

        private List<JoinedProspect> FillObjectCollection(IDataReader dataReader)
        {
            List<JoinedProspect> prospects = new List<JoinedProspect>();
            while (dataReader.Read())
            {
                JoinedProspect prospect = this.FillObject(dataReader);
                prospects.Add(prospect);
            }
            return prospects;
        }

        private JoinedProspect FillObject(IDataReader dataReader)
        {
             JoinedProspect joinedProspect = new JoinedProspect();

             joinedProspect.incorpName = DatabaseUtil.ToString(dataReader["NAME"]);
             joinedProspect.incropNameLSAD = DatabaseUtil.ToString(dataReader["NAMELSAD"]);
             joinedProspect.classFP = DatabaseUtil.ToString(dataReader["CLASSFP"]);
            joinedProspect.Address = DatabaseUtil.ToString(dataReader["CorrectedAddressLine1"]);
            joinedProspect.doNotContactFlag = DatabaseUtil.ToInt32(dataReader["DoNotContactFlag"]);
            joinedProspect.currentCustomerFlag = DatabaseUtil.ToInt32(dataReader["CurrentCustomerFlag"]);
            joinedProspect.CorrectedLatitude = DatabaseUtil.ToDouble(dataReader["CorrectedLatitude"]);
            joinedProspect.CorrectedLongitude = DatabaseUtil.ToDouble(dataReader["CorrectedLongitude"]);
            joinedProspect.cancelledFlag = DatabaseUtil.ToInt32(dataReader["CancelledFlag"]);
            joinedProspect.firstName = DatabaseUtil.ToString(dataReader["FirstName"]);
            joinedProspect.lastName = DatabaseUtil.ToString(dataReader["LastName"]);

            return joinedProspect;
        }


    }
}
