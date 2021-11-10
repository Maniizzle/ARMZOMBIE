using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ZombieSurvivalSocialNetwork.Core.Domain.Entities;

namespace SHOPRURETAIL.Application.Requests
{
    public class AddSurvivorCommandRequest
    {
        [Required]
        [MinLength(3)]
        public string FirstName { get; set; }
        [Required]
        [MinLength(3)]
        public string LastName { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        [Range(10, 100)]
        public int Age { get; set; }
        [Required]
        public decimal LastLocationLongitude { get; set; }
        [Required]
        public decimal LastLocationLatitude { get; set; }
        [Required]
        public List<Resource> Resources { get; set; }

    }

    public class Resource{
    
        [Range(1, 100)]
        public int Id { get; set; }
        public int Count { get; set; }
}

}
