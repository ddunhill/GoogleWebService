using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoogleWebService.Models
{
    public class Graph
    {
        public double Slope { get; internal set; }
        public double Intercept { get; internal set; }
        public double RSqd { get; internal set; }
    }
}