using CommonLib.Numerical;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace GoogleWebService.Models
{
    public class Pubs
    {
        public IList<Visit> ProcessValues(IList<IList<object>> values)
        {
            List<Visit> rset = new List<Visit>();
            if (values != null && values.Count > 0)
            {
                foreach (var row in values)
                {
                    if (row.Count > 2)
                    {
                        rset.Add(ProccessVisit(row));
                    }
                }
            }

            return rset;
        }        
        
        private Visit ProccessVisit(IList<object> row)
        {
            Visit working = new Visit
            {
                County = row[0].ToString(),
                Brewer = row[1].ToString(),
                Beer = row[2].ToString()
            };
            return working;
        }
    }
}