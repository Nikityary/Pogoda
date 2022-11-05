using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace база
{
    internal class Main
    {
        public double _temp;
        public double temp
        {
            get
            {
                return _temp;
            }
            set
            {
                _temp = value - 273.15; 
            }
        }

        public double _pressure;
        public double pressure
        {
            get
            {
                return _pressure;
            }
            set 
            { 
                _pressure = value/1.3332239; 
            }
        }

        public double humidity;

        public double _tempMin;
        public double tempMin
        {
            get
            {
                return _tempMin;
            }
            set
            {
                _tempMin = value - 273.15;
            }
        }

        public double _tempMax;
        public double tempMax
        {
            get
            {
                return _tempMax;
            }
            set
            {
                _tempMax = value - 273.15;
            }
        }
    }
}
