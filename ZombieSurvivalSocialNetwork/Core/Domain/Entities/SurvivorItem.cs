using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZombieSurvivalSocialNetwork.Core.Domain.Entities
{
    public class SurvivorItem
    {
        public int SurvivorId { get; set; }
        public virtual Survivor Survivor { get; set; }
        public int ItemId { get; set; }
        public virtual Item Item { get; set; }
        public int Count { get; set; }

    }
}
