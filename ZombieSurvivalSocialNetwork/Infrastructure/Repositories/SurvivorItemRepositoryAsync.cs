using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZombieSurvivalSocialNetwork.Core.Application.Features.Responses;
using ZombieSurvivalSocialNetwork.Core.Application.Interfaces.Repositories;
using ZombieSurvivalSocialNetwork.Core.Domain.Entities;
using ZombieSurvivalSocialNetwork.Infrastructure.Contexts;
using ZombieSurvivalSocialNetwork.Infrastructure.Repository;

namespace ZombieSurvivalSocialNetwork.Infrastructure.Repositories
{
    public class SurvivorItemRepositoryAsync : GenericRepositoryAsync<SurvivorItem>, ISurvivorItemRepositoryAsync
    {
        private readonly ZombieDbContext _dbContext;

        public SurvivorItemRepositoryAsync(ZombieDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<SurvivorItem>> GetAllSurvivorItems()
        {
            return await _dbContext.SurvivorItems
                .Include(c => c.Item)
                .Include(c => c.Survivor).ToListAsync();

        }

        public async Task<List<SurvivorItem>> GetSurvivorItemsByIds(List<int> ids)
        {
            return await _dbContext.SurvivorItems
                  .Where(c => ids.Contains(c.SurvivorId))
                 .Include(c => c.Item)
                 .Include(c => c.Survivor).ToListAsync();

        }

        public async  Task<List<SurvivorRequestResponse>> GetSurvivors()
        {
            var survivorsWithItem = await _dbContext
                .Survivors
                .Include(c => c.SurvivorItems)
                .ThenInclude(c => c.Item)
               .Select(c =>
               new SurvivorRequestResponse
               {

                   FirstName = c.FirstName,
                   LastName = c.LastName,
                   Gender = c.Gender.ToString(),
                   Age = c.Age,
                   LastLocation = c.LastLocation,
                   IsInfected = c.IsInfected,
                   Items = c.SurvivorItems.Select(c => new ItemResponse { Count = c.Count, Name = c.Item.Name, Point = c.Item.Point }).ToList()

               }).ToListAsync();


            return survivorsWithItem;
        }
    }
}
