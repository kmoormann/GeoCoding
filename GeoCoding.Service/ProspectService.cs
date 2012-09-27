using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeoCoding.Repository;
using System.Net;
using System.IO;

namespace GeoCoding.Model
{
    public interface IProspectService
    {
        IEnumerable<Prospect> getList();
        String makePrepData(Prospect prospect);
        void updateProspect(Prospect prospect);
    }

    public abstract class ProspectServiceBase : IProspectService
    {
        protected IProspectRepository prospectRepository = new ProspectRepository();

        private string apiKey = null;

        public virtual string ApiKey
        {
            get
            {
                return apiKey;
            }
            set
            {
                apiKey = value;
            }
        }

        public virtual string makePrepData(Prospect prospect)
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<Prospect> getList()
        {
            return prospectRepository.GetProspects();
        }

        public virtual void updateProspect(Prospect prospect)
        {
            prospectRepository.Update(prospect);
            System.Diagnostics.Debug.WriteLine("3 Prospect Service the update lat long is " + prospect.CorrectedLatitude + " " + prospect.CorrectedLongitude);
        }
    }


    public class ProspectServiceYahoo : ProspectServiceBase
    {
        public ProspectServiceYahoo()
        {
            ApiKey = "lpU1yPHV34ExWduHerXkGBQcrBu2DEE6aptAE2YnOJ5zzx9YFPU6ckkCryD4npI";
        }
                

        
        
        public override string makePrepData(Prospect prospect)
        {
            
            // Create a request using a URL that can receive a post. 
            WebRequest request = WebRequest.Create("http://where.yahooapis.com/geocode?q= " + prospect.CorrectedAddressLine1 + ",+" + prospect.CorrectedCity + ",+" + prospect.CorrectedState +"&appid=" + ApiKey );
            // Set the Method property of the request to POST.
            request.Method = "POST";
            // Create POST data and convert it to a byte array.
            string postData = "This is a test that posts this string to a Web server.";
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            // Set the ContentType property of the WebRequest.
            request.ContentType = "application/x-www-form-urlencoded";
            // Set the ContentLength property of the WebRequest.
            request.ContentLength = byteArray.Length;
            // Get the request stream.
            Stream dataStream = request.GetRequestStream();
            // Write the data to the request stream.
            dataStream.Write(byteArray, 0, byteArray.Length);
            // Close the Stream object.
            dataStream.Close();
            // Get the response.
            WebResponse response = request.GetResponse();
            // Display the status.
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            // Get the stream containing content returned by the server.
            dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader1 = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader1.ReadToEnd();
            // Display the content.
            //System.Diagnostics.Debug.WriteLine(responseFromServer);
            // Clean up the streams.
            reader1.Close();
            dataStream.Close();
            response.Close();

            System.Diagnostics.Debug.WriteLine(responseFromServer);

            return responseFromServer;
        }
        
        


    }

    public class ProspectServiceGoogle : ProspectServiceBase
    {
        // Google API
        public override string makePrepData(Prospect prospect)
        {
            // Create a request using a URL that can receive a post. 
            WebRequest request = WebRequest.Create("http://maps.googleapis.com/maps/api/geocode/xml?address=+" + prospect.CorrectedAddressLine1 + ",+" + prospect.CorrectedCity + ",+" + prospect.CorrectedState + "&sensor=false");
            // Set the Method property of the request to POST.
            request.Method = "POST";
            // Create POST data and convert it to a byte array.
            string postData = "This is a test that posts this string to a Web server.";
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            // Set the ContentType property of the WebRequest.
            request.ContentType = "application/x-www-form-urlencoded";
            // Set the ContentLength property of the WebRequest.
            request.ContentLength = byteArray.Length;
            // Get the request stream.
            Stream dataStream = request.GetRequestStream();
            // Write the data to the request stream.
            dataStream.Write(byteArray, 0, byteArray.Length);
            // Close the Stream object.
            dataStream.Close();
            // Get the response.
            WebResponse response = request.GetResponse();
            // Display the status.
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            // Get the stream containing content returned by the server.
            dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader1 = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader1.ReadToEnd();
            // Display the content.
            //System.Diagnostics.Debug.WriteLine(responseFromServer);
            // Clean up the streams.
            reader1.Close();
            dataStream.Close();
            response.Close();

            return responseFromServer;
        }
    }
}
