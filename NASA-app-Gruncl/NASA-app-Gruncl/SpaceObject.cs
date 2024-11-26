using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NASA_app_Gruncl
{
    public class SpaceObject
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public double Absolute_magnitude_h { get; set; }
        public double Estimated_diameter_min { get; set; }
        public double Estimated_diameter_max { get; set; }
        public bool Is_potentially_hazardous_asteroid { get; set; }
        public bool Is_sentry_object { get; set; }
        public string Close_approach_date { get; set; }

    public SpaceObject(string id, string name, double absolute_magnitude_h,
            double estimated_diameter_min, double estimated_diameter_max,
            bool is_potentially_hazardous_asteroid, bool is_sentry_object,
            string close_approach_date)
        {
            ID = id;
            Name = name;
            Absolute_magnitude_h = absolute_magnitude_h;
            Estimated_diameter_min = estimated_diameter_min;
            Estimated_diameter_max = estimated_diameter_max;
            Is_potentially_hazardous_asteroid = is_potentially_hazardous_asteroid;
            Is_sentry_object = is_sentry_object;
            Close_approach_date = close_approach_date;
        }
    }
}
