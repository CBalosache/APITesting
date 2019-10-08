using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneAPIProject
{
    class HearthstoneAPI
    {
        static void Main(string[] args)
        {
            HearthstoneData hd = new HearthstoneData();
            hd.GetSingleHeathStoneAPIItem("https://omgvamp-hearthstone-v1.p.rapidapi.com/info");
            Console.WriteLine(hd.HearthStoneAPIItem.ToString());
            for (int i = 0; i < hd.response.Headers.Count; i++)
            {
                Console.WriteLine(hd.response.Headers[i].ToString());
            }
            Console.ReadLine();
        }
    }
    public static class AppConfigReader
    {
        public static String BaseUri = ConfigurationManager.AppSettings["base_uri"];
    }
    public class HearthstoneData
    {
        public RestClient Client { get; set; }
        public IRestResponse response { get; set; }
        public JObject HearthStoneAPIItem { get; set; }
        public JArray HearthStoneAPIArray { get; set; }
        public string PostcodeSelected { get; set; }
        public HearthstoneData() => Client = new RestClient
        {
            BaseUrl = new Uri("https://omgvamp-hearthstone-v1.p.rapidapi.com/info")
        };
        public void GetSingleHeathStoneAPIItem(string input)
        {
            var client = new RestClient(input);
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-host", "omgvamp-hearthstone-v1.p.rapidapi.com");
            request.AddHeader("x-rapidapi-key", "0dda9d8302msh8d030811dfe2b41p1f571ajsnc2b718840881");
            response = client.Execute(request);
            HearthStoneAPIItem = JObject.Parse(response.Content.ToString());
        }
    }
}
