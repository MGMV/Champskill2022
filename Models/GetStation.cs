using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModulAZS.Models
{

    public class Rootobject
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public int FuelT92 { get; set; }
        public float Price92 { get; set; }
        public int AmountOfFuel92 { get; set; }
        public int Fuel95 { get; set; }
        public float Price95 { get; set; }
        public int AmountIfFuel95 { get; set; }
        public int Fuel98 { get; set; }
        public float Price98 { get; set; }
        public int AmountIfFuel98 { get; set; }
        public string FuelDis { get; set; }
        public float PriceDis { get; set; }
        public int AmountIfFuelDis { get; set; }
    }


}
