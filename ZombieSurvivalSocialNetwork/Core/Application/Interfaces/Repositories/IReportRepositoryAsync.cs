using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ZombieSurvivalSocialNetwork.Core.Application.Features.Responses;
using ZombieSurvivalSocialNetwork.Core.Application.Interfaces;

namespace SHOPRURETAIL.Application.Interfaces.Repositories
{
    public interface IReportRepositoryAsync
    {
        public Task<ReportQueryResponse> Report();



    }
}
