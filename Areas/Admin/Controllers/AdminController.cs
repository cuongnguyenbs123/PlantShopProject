using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
namespace AppBanDoDienTu.Areas
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            ViewBag.Title = "Index";
            string path = "https://servernodettandroid.herokuapp.com/product?fbclid=IwAR3mkKJNSCQKt9fl4MqvavN9lTFsZ1VasUsDYrfU9GGyfnEqlPLBtN19NfM";
            object products = GetProduct(path);
            JObject jObject = JObject.Parse(products.ToString());
            ViewBag.data = jObject["results"];
            return View();
        }
        public object GetProduct(string path)
        {
            using (WebClient webClient =new WebClient())
            {
                return JsonConvert.DeserializeObject<object>(webClient.DownloadString(path));
            }
        }
    }
}