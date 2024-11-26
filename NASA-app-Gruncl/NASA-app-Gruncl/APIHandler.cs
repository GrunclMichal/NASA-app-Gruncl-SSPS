using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;
using System.IO;
using Newtonsoft.Json.Linq;

namespace NASA_app_Gruncl
{
    class APIHandler
    {
        private string _API_URL;
        private static readonly HttpClient _client = new HttpClient();
        private static APIHandler _Instance = new APIHandler();
        public static APIHandler GetInstance(){ return _Instance; }
        private APIHandler()
        {
            string url = File.ReadAllText("../../../Api.txt");
            if (url== @"https://api.nasa.gov/neo/rest/v1/feed?")
            { _API_URL = url + $"start_date={DateTime.Now.ToString("yyyy'-'MM'-'dd")}&api_key=DEMO_KEY"; }
        }

        public async Task<List<SpaceObject>> GetAPIData()
        {
            HttpClient _client = new HttpClient();

            string url = File.ReadAllText("../../../Api.txt");
            if (url == @"https://api.nasa.gov/neo/rest/v1/feed?")
            { _API_URL = url + $"start_date={DateTime.Now.ToString("yyyy'-'MM'-'dd")}&api_key=DEMO_KEY"; }
            else _API_URL = url;

            HttpResponseMessage response = await _client.GetAsync(_API_URL);
            response.EnsureSuccessStatusCode();

            string responseData = await response.Content.ReadAsStringAsync();
            var json = JsonDocument.Parse(responseData);

            var asteroids = json.RootElement
                             .GetProperty("near_earth_objects")
                             .EnumerateObject()
                             .SelectMany(day => day.Value.EnumerateArray())
                             .Select(neo => new SpaceObject(
                                 neo.GetProperty("id").GetString(),
                                 neo.GetProperty("name").GetString(),
                                 GetDoubleValue(neo.GetProperty("absolute_magnitude_h")),
                                 GetDoubleValue(neo.GetProperty("estimated_diameter").GetProperty("kilometers").GetProperty("estimated_diameter_min")),
                                 GetDoubleValue(neo.GetProperty("estimated_diameter").GetProperty("kilometers").GetProperty("estimated_diameter_max")),
                                 neo.GetProperty("is_potentially_hazardous_asteroid").GetBoolean(),
                                 neo.GetProperty("is_sentry_object").GetBoolean(),
                                 neo.GetProperty("close_approach_data")[0].GetProperty("close_approach_date_full").GetString()
                                 )).ToList();

            return asteroids;
        }

        private double GetDoubleValue(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Number)
            {
                return element.GetDouble();
            }
            else if (element.ValueKind == JsonValueKind.String && double.TryParse(element.GetString(), out double result))
            {
                return result;
            }
            else
            {
                throw new Exception("Invalid data type for numeric value");
            }
        }
    }
}
