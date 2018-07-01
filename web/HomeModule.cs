using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nancy;
using Nancy.ModelBinding;

namespace web
{
    public class HomeModule : NancyModule
    {
        public HomeModule() //base("/1.0/api/")
        {
            Get("/", args => View["spa"]); // Index  (will use wwwroot/views/spa.sshtml)
            Get(@"/(.*)", args => View["spa", args]); // SPA fallback route


            // Sample "FetchData" route from MCV template
            Get("/api/SampleData/WeatherForecasts", args =>
            {

                var startDateIndex = 0;
                int.TryParse(Request.Query["startDateIndex "], out startDateIndex);
                string[] Summaries = new[]
                {
                    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
                };
                var rng = new Random();
                return Response.AsJson(Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    DateFormatted = DateTime.Now.AddDays(index + startDateIndex).ToString("d"),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                }));

            });

        }

        // Sample class from MCV template
        private class WeatherForecast
        {
            public string DateFormatted { get; set; }
            public int TemperatureC { get; set; }
            public string Summary { get; set; }

            public int TemperatureF {
                get {
                    return 32 + (int)(TemperatureC / 0.5556);
                }
            }
        };


    }
}
