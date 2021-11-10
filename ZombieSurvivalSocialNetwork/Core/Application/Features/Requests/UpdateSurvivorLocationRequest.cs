using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZombieSurvivalSocialNetwork.Core.Application.Features.Requests
{
    public class UpdateSurvivorLocationRequest
    {
        [Range(1, int.MaxValue)]
        public int SurvivorId { get; set; }
        [Required]
        public decimal LastLocationLongitude { get; set; }
        [Required]
        public decimal LastLocationLatitude { get; set; }
    }
}
