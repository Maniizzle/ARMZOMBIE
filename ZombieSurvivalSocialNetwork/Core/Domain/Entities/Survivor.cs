using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZombieSurvivalSocialNetwork.Core.Domain.Entities
{
    public class Survivor
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public string LastLocation { get; set; }
        public bool IsInfected { get; set; }
        public DateTime? DateInfected { get; set; }
        public ICollection<SurvivorItem> SurvivorItems { get; set; }
    }

    public enum Gender
    {
        Male,
        Female
    }

}
