using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace E_Shopping.Class
{
    public class DistanceCalculate
    {
        public static string BingMapsKey = "bL87M940PHGHkEzNpKCT~7l6e1ifOuzSkJb-SYq0aRA~AoJ-HOVsGdYPvQ2MvQKdhdzyQ-Gxxp_3ZfsE7O6_Ec0L1xosfPF27i7jAOEAlk2M";
        public static async Task<double> GetDistance(string fromAddress, string toAddress)
        {
            // Geocode the addresses to get their latitude and longitude coordinates
            var client = new HttpClient();
            var fromLocation = await client.GetStringAsync($"http://dev.virtualearth.net/REST/v1/Locations?q={fromAddress}&key={BingMapsKey}");
            var toLocation = await client.GetStringAsync($"http://dev.virtualearth.net/REST/v1/Locations?q={toAddress}&key={BingMapsKey}");
            var fromPoint = JObject.Parse(fromLocation)["resourceSets"][0]["resources"][0]["point"]["coordinates"];
            var toPoint = JObject.Parse(toLocation)["resourceSets"][0]["resources"][0]["point"]["coordinates"];

            // Calculate the distance using the Bing Maps REST Services API Distance Matrix API
            var distanceResponse = await client.GetStringAsync($"https://dev.virtualearth.net/REST/v1/Routes/DistanceMatrix?origins={fromPoint[0]},{fromPoint[1]}&destinations={toPoint[0]},{toPoint[1]}&travelMode=driving&key={BingMapsKey}");
            var distance = JObject.Parse(distanceResponse)["resourceSets"][0]["resources"][0]["results"][0]["travelDistance"].Value<double>();

            return distance;
        }

    }
}
