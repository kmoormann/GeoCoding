using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeoCoding.Model
{
    // holder class that is used when parsing data from the web api call to convert the 
    public class KmlPrepData
    {
        //public KmlPrepData();

        public double lat { get; set; }
        public double lng { get; set; }
        public string name { get; set; }

        
 
    }
}
