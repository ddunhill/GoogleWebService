using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoogleWebService.Models
{
    public class Results
    {
        public Results()
        {
            Races = new List<Race>();
            SwimLine = new Graph();
            BikeLine = new Graph();
            RunLine = new Graph();
        }

        public List<Race> Races { get; set; }
        public Graph SwimLine { get; internal set; }
        public Graph BikeLine { get; internal set; }
        public Graph RunLine { get; internal set; }
    }
}