using CommonLib.Numerical;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace GoogleWebService.Models
{
    public class Triathalon
    {
        public IList<Race> ProcessValues(IList<IList<object>> values)
        {
            Results rset = new Results();
            if (values != null && values.Count > 0)
            {
                foreach (var row in values)
                {
                    if (row.Count > 4)
                    {
                        rset.Races.Add(ProccessRace(row));
                    }
                }
            }

            return MakePredictions(rset).Races;
        }

        private Results MakePredictions(Results rset)
        {
            object graphline = PerformFitting(rset);

            List<Race> working = rset.Races.FindAll(x => x.T1Time != null);
            TimeSpan t1avg = new TimeSpan(Convert.ToInt64 (working.Average(x => ((TimeSpan)x.T1Time).Ticks)));
            TimeSpan t2avg = new TimeSpan(Convert.ToInt64(working.Average(x => ((TimeSpan)x.T2Time).Ticks)));

            foreach (var item in rset.Races)
            {
                if (item.SwimTime == null)
                {
                    int x = item.RaceDate.Year;
                    Graph s = rset.SwimLine;
                    item.SwimVelocity = s.Intercept + s.Slope * x;
                    Graph b = rset.BikeLine;
                    item.BikeVelocity = b.Intercept + b.Slope * x;
                    Graph r = rset.RunLine;
                    item.RunVelocity = r.Intercept + r.Slope * x;
                    item.TotalTime = t1avg + t2avg + item.RunTime + item.BikeTime + item.SwimTime;
                    item.Estimated = true;
                }
            }
            return rset;
        }

        private Results PerformFitting(Results rset)
        {
            List<Race> working = rset.Races.FindAll(x => x.SwimTime != null);
            double[] X = working.Select(i => (double)i.RaceDate.Year).ToArray();
            double[] swimY = working.Select(i => i.SwimVelocity).ToArray();
            var dswim = new XYDataSet(X, swimY);
            rset.SwimLine.Slope = dswim.Slope;
            rset.SwimLine.Intercept = dswim.YIntercept;
            rset.SwimLine.RSqd = dswim.ComputeRSquared();

            double[] bikeY = working.Select(i => i.BikeVelocity).ToArray();
            var dbike = new XYDataSet(X, bikeY);
            rset.BikeLine.Slope = dbike.Slope;
            rset.BikeLine.Intercept = dbike.YIntercept;
            rset.BikeLine.RSqd = dbike.ComputeRSquared();

            double[] runY = working.Select(i => i.RunVelocity).ToArray();
            var drun = new XYDataSet(X, runY);
            rset.RunLine.Slope = drun.Slope;
            rset.RunLine.Intercept = drun.YIntercept;
            rset.RunLine.RSqd = drun.ComputeRSquared();

            return rset;
        }
        
        private Race ProccessRace(IList<object> row)
        {
            TimeSpan temp;

            Race working = new Race
            {
                Name = row[0].ToString(),
                RaceDate = DateTime.ParseExact(row[1].ToString(), "d/M/yyyy", CultureInfo.CurrentCulture),
                SwimTime = TimeSpan.TryParse(row[2].ToString(), out temp) ? (TimeSpan?)temp : null,
                T1Time = TimeSpan.TryParse(row[3].ToString(), out temp) ? (TimeSpan?)temp : null,
                BikeTime = TimeSpan.TryParse(row[4].ToString(), out temp) ? (TimeSpan?)temp : null,
                T2Time = TimeSpan.TryParse(row[5].ToString(), out temp) ? (TimeSpan?)temp : null,
                RunTime = TimeSpan.TryParse(row[6].ToString(), out temp) ? (TimeSpan?)temp : null,
                TotalTime = TimeSpan.TryParse(row[7].ToString(), out temp) ? (TimeSpan?)temp : null,
                SwimDistance = Double.Parse(row[9].ToString().Replace("m",string.Empty))/1000,
                BikeDistance = Double.Parse(row[10].ToString().Replace("K", string.Empty)),
                RunDistance = Double.Parse(row[11].ToString().Replace("K", string.Empty)),
                CourseDescription = row.Count > 12 ? row[12].ToString() : string.Empty,
                BikeDescription = row.Count > 12 ? row[13].ToString() : string.Empty,
                SwimDescription = row.Count > 12 ? row[14].ToString() : string.Empty,
                Notes = row.Count > 12 ? row[15].ToString() : string.Empty,
                RaceClass = row.Count > 12 ? row[16].ToString() : string.Empty
            };
            return working;
        }
    }
}