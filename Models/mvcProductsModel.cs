using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace AppBanDoDienTu.Models
{
    public class mvcProductsModel
    {
        public string _id { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set;  }
        public int price { get; set; }
        public string img { get; set; }
        public int sortOut { get; set; }
        public int total { get; set; }
        public int promo { get; set; }
        public int id_producer { get; set; }
        public int __v { get; set; }
    }
}