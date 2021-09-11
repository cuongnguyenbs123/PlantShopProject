using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace AppBanDoDienTu
{
    public class GlobalVariables
    {
        public static HttpClient webApiClient = new HttpClient();
        GlobalVariables(){
            webApiClient.BaseAddress = new Uri("https://servernodettandroid.herokuapp.com/product?fbclid=IwAR3mkKJNSCQKt9fl4MqvavN9lTFsZ1VasUsDYrfU9GGyfnEqlPLBtN19NfM");
            webApiClient.DefaultRequestHeaders.Clear();
            webApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }
    }
}