using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeoCoding.Model
{
    //This class represents the prospects once they are joined with the geospacial data to determine if they are within the set bounds of the company
    public class JoinedProspect
    {
        public string incorpName { get; set; }
        public string incropNameLSAD { get; set; }
        public string classFP { get; set; }
        public string Address { get; set; }
        public int currentCustomerFlag { get; set; }
        public int cancelledFlag { get; set; }
        public int doNotContactFlag { get; set; }
        public double CorrectedLongitude { get; set; }
        public double CorrectedLatitude { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
    }
}
