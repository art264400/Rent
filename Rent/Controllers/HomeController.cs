using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Services;
using Geocoding;
using Geocoding.Google;
using Newtonsoft.Json;
using Rent.Context;
using Rent.Interfaces;
using Rent.Models;
using Rent.Models.Util;
using RestSharp;
using RestSharp.Serialization.Json;

namespace Rent.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public IRentService _rentService;

        public HomeController(IRentService rentService)
        {
            _rentService = rentService;
        }
        //public async Task<ActionResult> Index()

        public ActionResult Index()
        {
            //var client = new RestClient("https://geocode-maps.yandex.ru/1.x/");
            //var apikey = "a2676e6b-4540-4a36-9b7b-f7d6e77be65b";
            //var geocode = "Челябинск, новороссиякая 146";
            //var format = "json";
            //var request = new RestRequest("?apikey=" + apikey + "&geocode=" + geocode + "&format=" + format, Method.GET);
            ////https://geocode-maps.yandex.ru/1.x/?apikey=a2676e6b-4540-4a36-9b7b-f7d6e77be65b&geocode=Челябинск, новороссийская 146&format=json
            ////request.AddUrlSegment("{apikey}", "a2676e6b-4540-4a36-9b7b-f7d6e77be65b");
            ////request.AddUrlSegment("{geocode}", "%D0%A7%D0%B5%D0%BB%D1%8F%D0%B1%D0%B8%D0%BD%D1%81%D0%BA%2C+%D0%BD%D0%BE%D0%B2%D0%BE%D1%80%D0%BE%D1%81%D1%81%D0%B8%D0%B9%D1%81%D0%BA%D0%B0%D1%8F");
            ////request.AddUrlSegment("{format}", "json");
            //var content = client.Execute(request).Content;
            //MainClass res = JsonConvert.DeserializeObject<MainClass>(content);
            //String pos = res.response.GeoObjectCollection.featureMember[0].GeoObject.Point.pos;
            //String[] words = pos.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return View();
        }
        public JsonResult GetData()
        {
            var products = _rentService.GetAllProducts();
            // создадим список данных
            //List<Station> stations = new List<Station>();
            //stations.Add(new Station()
            //{
            //    Id = 1,
            //    PlaceName = "Библиотека имени Ленина",
            //    GeoLat = 37.610489,
            //    GeoLong = 55.752308,
            //    Line = "Сокольническая",
            //    Traffic = 1.0
            //});
            //stations.Add(new Station()
            //{
            //    Id = 2,
            //    PlaceName = "Александровский сад",
            //    GeoLat = 37.608644,
            //    GeoLong = 55.75226,
            //    Line = "Арбатско-Покровская",
            //    Traffic = 1.2
            //});
            //stations.Add(new Station()
            //{
            //    Id = 3,
            //    PlaceName = "Боровицкая",
            //    GeoLat = 37.609073,
            //    GeoLong = 55.750509,
            //    Line = "Серпуховско-Тимирязевская",
            //    Traffic = 1.0
            //});

            return Json(products, JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}