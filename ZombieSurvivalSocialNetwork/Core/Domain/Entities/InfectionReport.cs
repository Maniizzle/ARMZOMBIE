using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ZombieSurvivalSocialNetwork.Core.Domain.Entities
{
    public class InfectionReport
    {
        public int ReportingSurvivor { get; set; }

        public int ReportedSurvivor { get; set; }
    }
}
