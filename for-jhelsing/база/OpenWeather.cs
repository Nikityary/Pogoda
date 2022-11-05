using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace база
{
    internal class OpenWeather
    {
        public Coord coord;
        public Weather[] weather;
        [JsonProperty("base")]
        public string Base;
        public Main main;
        public double visibility;
        public Wind wind;
        public Clouds clouds;
        public double dt;
        public sys sys;
        public int id;
        public string name;
        public double code;


    }
}
