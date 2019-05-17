using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoogleWebService.Models
{
    public class Visit
    {
        public string County { get; set; }
        public string Brewer { get; set; }
        public string Beer { get; set; }
        public string Key { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Style { get; set; }
        public string Left { get; set; }
        public string Top { get; set; }
    }
}