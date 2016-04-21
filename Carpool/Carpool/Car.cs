using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Carpool
{
    internal class Car
    {
        public Car() { }

        public Car(string type, int cap, string license)
        {
            this.Type = type;
            this.Capacity = cap;
            this.License = license;
        }

        public string Type { get; set; }
        public int Capacity { get; set; }
        public string License { get; set; }
    }
}