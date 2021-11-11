using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZombieSurvivalSocialNetwork.Core.Domain.Entities;

namespace ZombieSurvivalSocialNetwork.Core.Application.Features.Responses
{
    public class SurvivorRequestResponse
    {
        public int SurvivorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string LastLocation { get; set; }
        public bool IsInfected { get; set; }
        public List<ItemResponse> Items { get; set; }
    
    }

    public class SurvivorItemResponse
    {
        public int SurvivorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public string LastLocation { get; set; }
        public bool IsInfected { get; set; }
        public string Name { get; set; }
        public int Point { get; set; }
        public int ItemId { get; set; }
        public int Count { get; set; }
    }

    public class ItemResponse
    {
        public string Name { get; set; }
        public int Point { get; set; }
        public int Count { get; set; }

    }
}
