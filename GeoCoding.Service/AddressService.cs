using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeoCoding.Model;
using SharpKml.Base;
using SharpKml.Dom;
using SharpKml.Engine;

namespace GeoCoding.Model
{
    public interface IAddressService
    {
        void addAddressToKML(Address address, KmlDocument kml);
    }

    public abstract class AddressServiceBase : IAddressService
    {
        public virtual void addAddressToKML(Address address, KmlDocument kmlDocument)
        {
            throw new NotImplementedException();
        }
    }

    public class AddressService : AddressServiceBase
    {
    }
}
