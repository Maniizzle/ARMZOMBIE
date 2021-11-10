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
    public class UpdateSurvivorLocationCommand: UpdateSurvivorLocationRequest, IRequest<Response<string>>
    {
    }

    public class UpdateSurvivorLocationCommandHandler : IRequestHandler<UpdateSurvivorLocationCommand, Response<string>>
    {
        private readonly IGenericRepositoryAsync<Survivor> _survivorRepo;
        public UpdateSurvivorLocationCommandHandler(IGenericRepositoryAsync<Survivor> survivorRepo)
        {
            _survivorRepo = survivorRepo;
        }

        public async Task<Response<string>> Handle(UpdateSurvivorLocationCommand request, CancellationToken cancellationToken)
        {
            var survivor=await _survivorRepo.GetByIdAsync(request.SurvivorId);
            if (survivor is null) throw new ApiException("Survivor not find");

            var lastlocation = $"{request.LastLocationLatitude},{request.LastLocationLongitude}";
            survivor.LastLocation = lastlocation;
            await _survivorRepo.UpdateAsync(survivor);
            return new Response<string>("Updated successfully");
        }
    }
}
