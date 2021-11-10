using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZombieSurvivalSocialNetwork.Core.Application.Features.Requests
{
    public class FlagSurvivorCommandRequest
    {
        [Required]
        [Range(1,int.MaxValue)]
        public int ReportingSurvivorId { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int SurvivorToReportId { get; set; }
    }
}
