using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ZombieSurvivalSocialNetwork.Core.Application.Exceptions;
using ZombieSurvivalSocialNetwork.Core.Application.Features.Requests;
using ZombieSurvivalSocialNetwork.Core.Application.Interfaces;
using ZombieSurvivalSocialNetwork.Core.Application.Wrappers;
using ZombieSurvivalSocialNetwork.Core.Domain.Entities;

namespace ZombieSurvivalSocialNetwork.Core.Application.Features.Survivors.Commands
{
    public class FlagSurvivorCommand: FlagSurvivorCommandRequest, IRequest<Response<string>>
    {
    }

    public class FlagSurvivorCommandHandler : IRequestHandler<FlagSurvivorCommand, Response<string>>
    {
        private readonly IGenericRepositoryAsync<Survivor> _survivorRepo;
        private readonly IGenericRepositoryAsync<InfectionReport> _infectionReportRepo;
        public FlagSurvivorCommandHandler(IGenericRepositoryAsync<Survivor> survivorRepo, IGenericRepositoryAsync<InfectionReport> infectionReportRepo)
        {
            _infectionReportRepo = infectionReportRepo;
            _survivorRepo = survivorRepo;
        }

        public async Task<Response<string>> Handle(FlagSurvivorCommand request, CancellationToken cancellationToken)
        {
            var survivorsId= new List<int>{ request.ReportingSurvivorId,request.SurvivorToReportId };
            var survivors = _survivorRepo.GetByParameter(c => survivorsId.Contains(c.Id)).ToList();

            if(survivors.Any(c=>c.Id==request.SurvivorToReportId && c.IsInfected)) throw new ApiException("Thank you. Survivor is known to be Infected ");
            
            if(_infectionReportRepo.GetByParameter(c=>c.ReportingSurvivor==request.ReportingSurvivorId).FirstOrDefault() is not null) 
            throw new ApiException("you cannot report a survivor twice");

            var infectionReports = _infectionReportRepo.GetByParameter(c => c.ReportedSurvivor == request.SurvivorToReportId).ToList();
            if (infectionReports.Count == 2)
            {
                var InfectedSurvivor = survivors.FirstOrDefault(c => c.Id == request.SurvivorToReportId);
                InfectedSurvivor.IsInfected = true;
                await _survivorRepo.UpdateAsync(InfectedSurvivor);

            }
             await _infectionReportRepo.AddAsync(new InfectionReport { ReportedSurvivor = request.SurvivorToReportId, ReportingSurvivor = request.ReportingSurvivorId });

            return new Response<string>($"Report has been been recorded ");
        }
    }
}
