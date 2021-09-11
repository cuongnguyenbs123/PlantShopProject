using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using AppBanDoDienTu.Models;
using System.Net.Http;
using System.IO;
using System.Text;
namespace AppBanDoDienTu.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            ViewBag.Title = "Index";
            string path = "https://servernodettandroid.herokuapp.com/product?id=5&name=Iphone&fbclid=IwAR3addMmDzpNFaxN-WyeKwra4xoVdPUf-A23Bb1lYAgod2sa2eNPbWKp18g";
             object products = GetProduct(path);
              JObject ob = JObject.Parse(products.ToString());
             ViewBag.data = ob["products"];
            return View();
        }
        public object GetProduct(string path)
        {
            using (WebClient webClient = new WebClient())
            {
                return JsonConvert.DeserializeObject<object>(
                    webClient.DownloadString(path));
            }
        }
       
       [HttpGet]
       public ActionResult Post()
        {
            return View();
        }
      [HttpPost]
        public ActionResult Post(mvcProductsModel model)
        {
            string path = string.Format("https://servernodettandroid.herokuapp.com/product?id="+model.id+ "&name="
                +model.name+ "&description="+model.description+ "&price="+model.price.ToString()+ "&img="+model.img+ "&sortOut="
                +model.sortOut.ToString()+ "&total="+model.total.ToString()+ "&id_producer="+model.id_producer.ToString());
            WebRequest res = WebRequest.Create(path);
            res.Method = "POST";
            res.ContentType = "application/json";
            WebResponse response = res.GetResponse();
         
            return RedirectToAction("Index", "Products");
        }
       
        public ActionResult Delete(string id)
        {
            string path = string.Format("https://servernodettandroid.herokuapp.com/product?_id="+id );
             WebRequest res = WebRequest.Create(path);
                res.Method = "DELETE";
                res.ContentType = "application/json";
                HttpWebResponse response = (HttpWebResponse)res.GetResponse();

         
            return RedirectToAction("Index", "Products");
        }
        [HttpGet]
        public ActionResult Put(string id)
        {
            string path = string.Format("https://servernodettandroid.herokuapp.com/product/search?_id=" + id);
            WebRequest res = WebRequest.Create(path);
            res.Method = "GET";
            res.ContentType = "application/json";
            WebResponse response = res.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string jsontype = reader.ReadToEnd();
            mvcProductsModel model = JsonConvert.DeserializeObject<mvcProductsModel>(jsontype);
            return View(model);
        }
        
        [HttpPost]
        public ActionResult Put(mvcProductsModel  model)
        {
            string path = string.Format("https://servernodettandroid.herokuapp.com/product/update?_id=" + 
                model.id + "&price=" + model.price.ToString()+"&total="+model.total.ToString()+"&promo="+model.promo.ToString());
            WebRequest res = WebRequest.Create(path);
            res.Method = "PUT";
            res.ContentType = "application/json";
            HttpWebResponse response = (HttpWebResponse)res.GetResponse();
            return RedirectToAction("Index", "Products");
        }
        public ActionResult BillsofSale()
        {
            string path = string.Format("https://servernodettandroid.herokuapp.com/bill");
            object bills = GetProduct(path);
              JObject ob = JObject.Parse(bills.ToString());
              ViewBag.data = ob["bill"];
            return View();
        }
        public ActionResult DeleteBill(string id)
        {
            string path=string.Format("https://servernodettandroid.herokuapp.com/bill?_id=" + id);
            WebRequest res = WebRequest.Create(path);
            res.Method = "DELETE";
            res.ContentType = "application/json";
            HttpWebResponse response = (HttpWebResponse)res.GetResponse();
            return RedirectToAction("BillsofSale", "Products");
        }
        [HttpGet]
        public ActionResult PutBill(string id)
        {
            string path = string.Format("https://servernodettandroid.herokuapp.com/bill/search?_id=" + id);
            WebRequest res = WebRequest.Create(path);
            res.Method = "GET";
            res.ContentType = "application/json";
            WebResponse response = res.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string jsontype = reader.ReadToEnd();
            Bills model = JsonConvert.DeserializeObject<Bills>(jsontype);
            return View(model);
        }
        [HttpPut]
        public ActionResult PutBill(Bills model)
        {
            string path = string.Format("https://servernodettandroid.herokuapp.com/bill/update?_id=" +
               model.id + "&username=" + model.username.ToString() + "&total=" + model.total.ToString() + "&id_product=" + model.id_product.ToString());
            WebRequest res = WebRequest.Create(path);
            res.Method = "PUT";
            res.ContentType = "application/json";
            HttpWebResponse response = (HttpWebResponse)res.GetResponse();
            return RedirectToAction("Index", "Products");
        }
    }
}