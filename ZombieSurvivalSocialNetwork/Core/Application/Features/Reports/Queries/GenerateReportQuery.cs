using AutoMapper;
using MediatR;
using SHOPRURETAIL.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ZombieSurvivalSocialNetwork.Core.Application.Exceptions;
using ZombieSurvivalSocialNetwork.Core.Application.Features.Responses;
using ZombieSurvivalSocialNetwork.Core.Application.Interfaces;
using ZombieSurvivalSocialNetwork.Core.Application.Wrappers;
using ZombieSurvivalSocialNetwork.Core.Domain.Entities;

namespace ZombieSurvivalSocialNetwork.Core.Application.Features.Reports.Queries
{
    public class GenerateReportQuery:  IRequest<Response<ReportQueryResponse>>
    {
    }

    public class GenerateReportQueryHandler : IRequestHandler<GenerateReportQuery, Response<ReportQueryResponse>>
    {
        private readonly IReportRepositoryAsync _reportRepo;
        public GenerateReportQueryHandler(IReportRepositoryAsync reportRepo)
        {
            _reportRepo = reportRepo;
        }

        public async Task<Response<ReportQueryResponse>> Handle(GenerateReportQuery request, CancellationToken cancellationToken)
        {
          

            var reports = await _reportRepo.Report();
            if (reports == null) throw new ApiException("reports cannot be found");

            return new Response<ReportQueryResponse> { Data=reports};
        }
    }
}
