using Microsoft.EntityFrameworkCore;
using SHOPRURETAIL.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZombieSurvivalSocialNetwork.Core.Application.Features.Responses;
using ZombieSurvivalSocialNetwork.Infrastructure.Contexts;

namespace ZombieSurvivalSocialNetwork.Infrastructure.Repositories
{
    public class ReportRepositoryAsync: IReportRepositoryAsync
    {
        private readonly ZombieDbContext _dbContext;

        public ReportRepositoryAsync(ZombieDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<ReportQueryResponse> Report()
        {

//            Average amount of each kind of resource by survivor(e.g. 5 waters per
//              survivor)
             var frequency= await _dbContext.Survivors
             .GroupBy(x => x.IsInfected)
             .Select(g => 
                     new {
                     InfectionStatus = g.Key,
                     Count = g.Count()
                     }).ToListAsync();

           var totalCount= frequency.Sum(x => x.Count);
           var notInfected = _dbContext.Survivors.Where(x => x.IsInfected == false).Count();
            double notInfectedPercentage = (notInfected / totalCount) * 100;
            double infectedPercentage = ((totalCount - notInfected) / totalCount) * 100;
            
            var average = await _dbContext.SurvivorItems
               .Include(c => c.Item)
               .Include(c => c.Survivor)
               .GroupBy(c => c.Item.Name).Select(c =>
                 new Average
                 {
                     NameOfResource = c.Key,
                     Averagee = c.Average(c => c.Count)
                 }
                ).ToListAsync();

            var infectedsurvivorsReport = await _dbContext.SurvivorItems
                  .Where(c => c.Survivor.IsInfected == false).Include(c => c.Item)
                  .Include(c => c.Survivor).Select(c=>new {ItemName= c.Item.Name, Points=c.Count*c.Item.Point })
                  .GroupBy(c => c.ItemName).Select(c =>
                    new PointsLost
                    {
                       Name = c.Key,
                       PointLost = c.Sum(c => c.Points)
                    }
                   ).ToListAsync();

            return new ReportQueryResponse {
                InfectedSurvivorPercentage = $"{infectedPercentage}%",
                NonInfectedSurvivorPercentage = $"{notInfectedPercentage}%",
                Averages = average,
                PointsLostObject = infectedsurvivorsReport,
                PointsLost = infectedsurvivorsReport.Sum(c => c.PointLost)
            };
        }
    }
}
