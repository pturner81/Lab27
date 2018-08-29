using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Lab27.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        { 
            HttpWebRequest APIRequest = WebRequest.CreateHttp("https://forecast.weather.gov/MapClick.php?lat=38.427341&lon=-86.9624086&FcstType=json");
            APIRequest.UserAgent = "Mozilla / 5.0(Windows NT 6.1; Win64; x64; rv: 47.0) Gecko / 20100101 Firefox / 47.0";

            HttpWebResponse APIWebResponse = (HttpWebResponse)APIRequest.GetResponse();
            if (APIWebResponse.StatusCode == HttpStatusCode.OK)
            {//if we got status == 200 (errthing is good)
                //get the data and parse it
                StreamReader ResponseData = new StreamReader(APIWebResponse.GetResponseStream());

                string Weather = ResponseData.ReadToEnd(); //reads the data from the response

                //Parses the JSON data
                JObject jsonWeather = JObject.Parse(Weather);
                ViewBag.Weather = jsonWeather;

            }
            return View();
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