using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConvertToGeoJson
{
    public class StopGeo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public string Direction { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public Localization Loc { get; set; }
    }

    public class Localization
    {
        public string Type { get; set; }
        public List<double> Coordinates { get; set; }
    }
}
