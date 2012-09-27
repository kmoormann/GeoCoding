using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Text;
using System.IO;
using SharpKml.Base;
using SharpKml.Dom;
using SharpKml.Engine;
using Newtonsoft.Json;
using System.Xml;
using GeoCoding.Model;
using System.Xml.Linq;



namespace GeoCoding.Controllers
{
    public class AddressController : Controller
    {
        IKmlPrepDataService _kmlPrepDataService; 
        IKmlDocumentService _kmlDocumentService; 
        IProspectService _prospectSerivce; 
        IJoinedProspectService _joinedProspectService;
        
        public AddressController()
        {
            _kmlPrepDataService = new KmlPrepDataService();
            _kmlDocumentService = new KmlDocumentService();
            _prospectSerivce = new ProspectServiceYahoo();
            _joinedProspectService = new JoinedProspectService();
        }

        public AddressController(IKmlPrepDataService prepDataService, IKmlDocumentService kmlDocService, IProspectService prospectService, IJoinedProspectService joinedProspectService)
        {
            _kmlPrepDataService = prepDataService;
            _kmlDocumentService = kmlDocService;
            _prospectSerivce = prospectService;
            _joinedProspectService = joinedProspectService;
        }
        //
        // GET: /Address/
        
        public ActionResult Index()
        {
            



            return View();
        }
            

        [HttpPost]
        public ActionResult Index(String address, String city, String state)
        {
            

            ViewBag.Message = address;
            ViewBag.City = city;
            ViewBag.State = state;

            //var json1 = new WebClient().DownloadString("http://maps.googleapis.com/maps/api/geocode/json?address=+" + address + ",+" + city + ",+" + state + "&sensor=false");
            // now use json.net

            //KmlPrepData kmlPrepDataHardCode = new KmlPrepData();
            //kmlPrepDataHardCode.name = "Hard Code";
            //kmlPrepDataHardCode.lat = 10.0;
            //kmlPrepDataHardCode.lng = 10.0;
            //kmlDocumentService.addAddresstoKmlDocument(kmlPrepDataHardCode, document);
            

            

        
            return View();

        }

        public ActionResult Refresh()
        {
            IEnumerable<Prospect> prospectList = _prospectSerivce.getList();
            int counter = 0;
            Document document = new Document();

            // get lat and long for each prospect
            foreach (Prospect prospect in prospectList)
            {
                // some api's will only allow x calls per second this sleeper helps to space out the calls made to the web service
                counter = counter + 1;
                if (counter % 10 == 0)
                {
                    System.Diagnostics.Debug.WriteLine("Sleeping" + counter);
                    System.Threading.Thread.Sleep(5000);
                }

                String responseFromServer = _prospectSerivce.makePrepData(prospect);
                KmlPrepData kmlPrepData = new KmlPrepData();
                //System.Diagnostics.Debug.WriteLine(responseFromServer);
                kmlPrepData = _kmlPrepDataService.convertAddress(responseFromServer);

                // update lat long to the database
                _prospectSerivce.updateProspect(prospect);
            }

            //run stored procedure to update db
            IEnumerable<JoinedProspect> joinedPospects = _joinedProspectService.getList();

            // get results
            //create styles for placemarkers
            var doNotContactStyle = new Style();
            doNotContactStyle.Id = "doNoContact";
            doNotContactStyle.Icon = new IconStyle();
            doNotContactStyle.Icon.Color = new Color32(255, 0, 255, 0);
            doNotContactStyle.Icon.ColorMode = ColorMode.Normal;
            doNotContactStyle.Icon.Icon = new IconStyle.IconLink(new Uri("http://maps.google.com/mapfiles/kml/pal3/icon47.png"));
            doNotContactStyle.Icon.Scale = 1.1;

            var currentCustomerStyle = new Style();
            currentCustomerStyle.Id = "currentCustomer";
            currentCustomerStyle.Icon = new IconStyle();
            currentCustomerStyle.Icon.Color = new Color32(255, 0, 255, 0);
            currentCustomerStyle.Icon.ColorMode = ColorMode.Normal;
            currentCustomerStyle.Icon.Icon = new IconStyle.IconLink(new Uri("http://maps.google.com/mapfiles/kml/pal3/icon23.png"));
            currentCustomerStyle.Icon.Scale = 1.1;

            var cancelledCustomerStyle = new Style();
            cancelledCustomerStyle.Id = "cancelledCustomer";
            cancelledCustomerStyle.Icon = new IconStyle();
            cancelledCustomerStyle.Icon.Color = new Color32(255, 0, 255, 0);
            cancelledCustomerStyle.Icon.ColorMode = ColorMode.Normal;
            cancelledCustomerStyle.Icon.Icon = new IconStyle.IconLink(new Uri("http://maps.google.com/mapfiles/kml/pal3/icon51.png"));
            cancelledCustomerStyle.Icon.Scale = 1.1;
            //add results to document
            foreach (JoinedProspect jp in joinedPospects)
            {
                // loop through and add information to kmldocument 
                KmlPrepData kmlPrepData = new KmlPrepData();
                _kmlDocumentService.addElementToKmlDocument(jp, document);

            }


            document.AddStyle(doNotContactStyle);
            document.AddStyle(currentCustomerStyle);
            document.AddStyle(cancelledCustomerStyle);

            //var serializer = new Serializer();
            //serializer.Serialize(document);
            //System.Diagnostics.Debug.WriteLine(serializer.Xml);


            _kmlDocumentService.saveKmlDocument(document);
            return View();
        }



        //
        // GET: /Address/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Address/Create

        [HttpPost]
        public ActionResult Create(String address)
        {
            ViewBag.Message = address;
            return View();

        }

       
        public ActionResult xml()
        {
            //string helper = htmlHelper.ViewContext.HttpContext.Server.MapPath("~/product.xml");
            Response.ContentType = "text/xml";

            XmlDocument xDoc = new XmlDocument();
            string ServerPath = HttpContext.Server.MapPath("//DroidArmy.kml");
            xDoc.Load(ServerPath);
            String temp = xDoc.InnerXml;

            ViewBag.xmlDoc = temp;

            System.Diagnostics.Debug.WriteLine("This is the xml Action Request");

            XElement _x = XElement.Load(ServerPath);

            UrlHelper u = new UrlHelper(this.ControllerContext.RequestContext);


            return View();
        }
    }

}
