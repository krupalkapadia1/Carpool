using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Carpool
{
    internal class Ride
    {
        public Ride() { }

        public Ride(string username, string start, string dest, string date, string time)
        {
            this.Driver = username;
            this.StartingPoint = start;
            this.Destination = dest;
            this.Date = date;
            this.Time = time;
            this.Car = null;
            this.Isfull = false;
        }

        public string Driver { get; set; }
        public string StartingPoint { get; set; }
        public string Destination { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public Car Car { get; set; }
        public bool Isfull { get; set; }

        public string[] getDetails()
        {
            string[] details = new string[] { this.Driver, this.StartingPoint, this.Destination, this.Date, this.Time };
            return details;
        }

        public void setCar(Car carObj)
        {
            this.Car = carObj;
        }

    }


}