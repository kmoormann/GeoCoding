using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;


namespace GeoCoding.Model
{
    public interface IKmlPrepDataService
    {
        KmlPrepData convertAddress(String xml);
    }

    public abstract class KmlPrepDataServiceBase : IKmlPrepDataService
    {
        public virtual KmlPrepData convertAddress(string xml)
        {
            throw new NotImplementedException();
        }
    }


    public class KmlPrepDataService : KmlPrepDataServiceBase
    {
        // the class parses through returned xml and gets values for lat and long
        public override KmlPrepData convertAddress(String xml)
        {
            KmlPrepData kmlPrepData = new KmlPrepData();

            StringBuilder output = new StringBuilder();
            using (XmlReader reader = XmlReader.Create(new StringReader(xml)))
            {
                XmlWriterSettings ws = new XmlWriterSettings();
                ws.Indent = true;
                using (XmlWriter writer = XmlWriter.Create(output, ws))
                {

                    

                    reader.ReadToFollowing("latitude");
                    kmlPrepData.lat = reader.ReadElementContentAsDouble();

                    //reader.ReadToFollowing("offsetlon");
                    kmlPrepData.lng = reader.ReadElementContentAsDouble();
                    
                    reader.ReadToFollowing("line1");
                    kmlPrepData.name = reader.ReadElementContentAsString();

                    

                }
            }

            return kmlPrepData;
        }
    }
}
