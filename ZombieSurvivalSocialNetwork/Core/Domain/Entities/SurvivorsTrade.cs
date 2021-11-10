using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZombieSurvivalSocialNetwork.Core.Domain.Entities
{
    public class SurvivorsTrade
    {
        public int Id { get; set; }
        public int RequestingSurvivior { get; set; }
        public int RequestedSurvivior { get; set; }
        public virtual List<SurvivorsRequestAndResponseResource> SurvivorsRequestAndResponseResource { get; set; }
        public RequestStatus RequestStatus { get; set; }
        public DateTime DateOfTrade { get; set; } = DateTime.Now;
    }

    public class SurvivorsRequestAndResponseResource
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public Item Item { get; set; }
        public int Count { get; set; }
        public int Point { get; set; }
        public bool IsResponse { get; set; }
        public int SurvivorsTradeId { get; set; }
        public virtual SurvivorsTrade SurvivorsTrade { get; set; }
    }

    public enum RequestStatus 
    {
        Pending,
        Successful,
        Cancelled
    }

}
