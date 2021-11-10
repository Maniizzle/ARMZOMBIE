using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZombieSurvivalSocialNetwork.Core.Domain.Entities;

namespace ZombieSurvivalSocialNetwork.Core.Application.Interfaces.Repositories
{
   public interface ISurvivorItemRepositoryAsync : IGenericRepositoryAsync<SurvivorItem>
    {
        public  Task<List<SurvivorItem>> GetAllSurvivorItems();
        public Task<List<SurvivorItem>> GetSurvivorItemsByIds(List<int> ids);


    }
}
