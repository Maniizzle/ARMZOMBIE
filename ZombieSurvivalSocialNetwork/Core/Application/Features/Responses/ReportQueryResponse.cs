

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZombieSurvivalSocialNetwork.Core.Application.Features.Responses
{
    public class ReportQueryResponse
    {
        public string InfectedSurvivorPercentage { get; set; }
        public string NonInfectedSurvivorPercentage { get; set; }
        public List<Average> Averages { get; set; }
        public List<PointsLost> PointsLostObject { get; set; }
        public double PointsLost { get; set; }

    }

    public class PointsLost
    {
        public string Name { get; set; }
        public double PointLost { get; set; }
        public double Average { get; set; }
    }
    public class Average
    {
        public string NameOfResource { get; set; }
        public double Averagee { get; set; }
    }
}
