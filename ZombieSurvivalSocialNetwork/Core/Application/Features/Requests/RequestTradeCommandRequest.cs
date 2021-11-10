using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZombieSurvivalSocialNetwork.Core.Application.Features.Requests
{
    public class RequestTradeCommandRequest
    {

        [Required]
        [Range(1, int.MaxValue)]
        public int RequestingSurviviorId { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int RequestedSurviviorId { get; set; }
        [Required]
        public List<RequestResource> SurvivorsRequestResource { get; set; }
    }

    public class RequestResource 
    {
        public int Id { get; set; }
        public int Count { get; set; }

    }

}
