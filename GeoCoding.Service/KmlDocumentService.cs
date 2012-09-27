using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpKml.Base;
using SharpKml.Dom;
using SharpKml.Engine;

namespace GeoCoding.Model
{
    public class KmlDocumentService
    {
       public void addAddresstoKmlDocument(KmlPrepData prepData, Document KmlDoc)
        {
            Point point = new Point();

            point.Coordinate = new Vector(prepData.lat, prepData.lng);

            Placemark placemark = new Placemark();
            placemark.Geometry = point;
            placemark.Name = prepData.name;

            KmlDoc.AddFeature(placemark);
        }
        // this adds an element to the document and adds a place marker 
        public void addElementToKmlDocument(JoinedProspect joinedProspect, Document kmlDoc)
       {
           Point point = new Point();

           point.Coordinate = new Vector(joinedProspect.CorrectedLatitude, joinedProspect.CorrectedLongitude);

           Placemark placemark = new Placemark();
           placemark.Geometry = point;
           placemark.Name = joinedProspect.firstName + " " + joinedProspect.lastName;
           placemark.Address = joinedProspect.Address;
           placemark.Description = new Description() { Text = "ClassFP: " + joinedProspect.classFP + " IncorpName: " + joinedProspect.incorpName + " Address: " + joinedProspect.Address + " <h3>HelloWorld</h3>"};
           classifyProspect(joinedProspect, placemark);
           
                      
           kmlDoc.AddFeature(placemark);
       }

        public void saveKmlDocument(Document kmlDoc)
       {
           // This allows us to save and Element easily.
           var kml = new Kml();
           
           kml.AddNamespacePrefix(KmlNamespaces.GX22Prefix, KmlNamespaces.GX22Namespace);
           kml.Feature = kmlDoc;

            
           KmlFile kmlF = KmlFile.Create(kml, false);

           kmlF.Save(@"mykmlFile.kml");
       }
        // TODO: Need to change so that you can handle 1's and 2's in column not just not 0
        public void classifyProspect(JoinedProspect joinedProspect ,Placemark placemark)
        {
            if (joinedProspect.currentCustomerFlag != 0)
            {
                placemark.StyleUrl = new Uri("#currentCustomer", UriKind.Relative);
            }
            else if (joinedProspect.doNotContactFlag != 0)
            {
                placemark.StyleUrl = new Uri("#doNoContact", UriKind.Relative);
            }
            else if (joinedProspect.cancelledFlag != 0)
            {
                placemark.StyleUrl = new Uri("#cancelledCustomer", UriKind.Relative);
            }
        }
    }
}
