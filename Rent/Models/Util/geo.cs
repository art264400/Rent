//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

//namespace Rent.Models.Util
//{
//    public class geo
//    {

//        public Point point { get; set; }
//        public Rootobject rootobject { get; set; }
//        public Response response { get; set; }
//        public Geoobjectcollection geoobjectcollection { get; set; }
//        public Metadataproperty metadataproperty { get; set; }
//        public Geocoderresponsemetadata geocoderresponsemetadata { get; set; }
//        public Featuremember featuremember { get; set; }
//        public Geoobject geoobject { get; set; }

//        public Metadataproperty1 metadataproperty1 { get; set; }
//        public Geocodermetadata geocodermetadata { get; set; }
//        public Address address { get; set; }
//        public Component component { get; set; }
//        public Addressdetails addressdetails { get; set; }
//        public Country country { get; set; }

//        public Administrativearea administrativearea { get; set; }
//        public Subadministrativearea subadministrativearea { get; set; }
//        public Locality locality { get; set; }
//        public Thoroughfare thoroughfare { get; set; }
//        public Premise premise { get; set; }
//        public Postalcode postalcode { get; set; }
//        public Boundedby boundedby { get; set; }
//        public Envelope envelope { get; set; }
//    }
//    public class Point
//    {
//        public string pos { get; set; }
//    }
//    public class Rootobject
//    {
//        public Response response { get; set; }
//    }

//    public class Response
//    {
//        public Geoobjectcollection GeoObjectCollection { get; set; }
//    }

//    public class Geoobjectcollection
//    {
//        public Metadataproperty metaDataProperty { get; set; }
//        public Featuremember[] featureMember { get; set; }
//    }

//    public class Metadataproperty
//    {
//        public Geocoderresponsemetadata GeocoderResponseMetaData { get; set; }
//    }

//    public class Geocoderresponsemetadata
//    {
//        public string request { get; set; }
//        public string results { get; set; }
//        public string found { get; set; }
//    }

//    public class Featuremember
//    {
//        public Geoobject GeoObject { get; set; }
//    }

//    public class Geoobject
//    {
//        public Metadataproperty1 metaDataProperty { get; set; }
//        public string name { get; set; }
//        public string description { get; set; }
//        public Boundedby boundedBy { get; set; }
//        public Point Point { get; set; }
//    }

//    public class Metadataproperty1
//    {
//        public Geocodermetadata GeocoderMetaData { get; set; }
//    }

//    public class Geocodermetadata
//    {
//        public string precision { get; set; }
//        public string text { get; set; }
//        public string kind { get; set; }
//        public Address Address { get; set; }
//        public Addressdetails AddressDetails { get; set; }
//    }

//    public class Address
//    {
//        public string country_code { get; set; }
//        public string formatted { get; set; }
//        public string postal_code { get; set; }
//        public Component[] Components { get; set; }
//    }

//    public class Component
//    {
//        public string kind { get; set; }
//        public string name { get; set; }
//    }

//    public class Addressdetails
//    {
//        public Country Country { get; set; }
//    }

//    public class Country
//    {
//        public string AddressLine { get; set; }
//        public string CountryNameCode { get; set; }
//        public string CountryName { get; set; }
//        public Administrativearea AdministrativeArea { get; set; }
//    }

//    public class Administrativearea
//    {
//        public string AdministrativeAreaName { get; set; }
//        public Subadministrativearea SubAdministrativeArea { get; set; }
//    }

//    public class Subadministrativearea
//    {
//        public string SubAdministrativeAreaName { get; set; }
//        public Locality Locality { get; set; }
//    }

//    public class Locality
//    {
//        public string LocalityName { get; set; }
//        public Thoroughfare Thoroughfare { get; set; }
//    }

//    public class Thoroughfare
//    {
//        public string ThoroughfareName { get; set; }
//        public Premise Premise { get; set; }
//    }

//    public class Premise
//    {
//        public string PremiseNumber { get; set; }
//        public Postalcode PostalCode { get; set; }
//    }

//    public class Postalcode
//    {
//        public string PostalCodeNumber { get; set; }
//    }

//    public class Boundedby
//    {
//        public Envelope Envelope { get; set; }
//    }

//    public class Envelope
//    {
//        public string lowerCorner { get; set; }
//        public string upperCorner { get; set; }
//    }

//}

