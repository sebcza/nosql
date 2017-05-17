using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConvertToGeoJson
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string path = @".\"+args[0];

            // This text is added only once to the file.
            if (!File.Exists(path))
            {
                Console.WriteLine("Files non exist");
            }
            List<string> lines = File.ReadLines(path).ToList();
            var outPutFile = File.OpenWrite(@".\geoResult.json");
            System.IO.StreamWriter file = new System.IO.StreamWriter(outPutFile);
            lines.ForEach(line =>
            {
                Console.WriteLine(line);
                Stop stop = JsonConvert.DeserializeObject<Stop>(line);
                StopGeo stopGeo = new StopGeo()
                {
                    City = stop.City,
                    Direction = stop.Direction,
                    Name = stop.Name,
                    Number = stop.Number,
                    Street = stop.Street,
                    Id = stop.Id,
                    Loc = new Localization()
                    {
                        Type = "Point",Coordinates = new List<double>() { Double.Parse(stop.Lat), Double.Parse(stop.Long)}
                    }
                };
                
                file.WriteLine(JsonConvert.SerializeObject(stopGeo));
            });
           
            outPutFile.Dispose();
            Console.WriteLine();
        }
    }
}
