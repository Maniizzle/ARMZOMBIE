using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ZombieSurvivalSocialNetwork.Core.Application.Features.Responses;
using ZombieSurvivalSocialNetwork.Core.Application.Interfaces;
using ZombieSurvivalSocialNetwork.Core.Application.Interfaces.Repositories;
using ZombieSurvivalSocialNetwork.Core.Application.Wrappers;
using ZombieSurvivalSocialNetwork.Core.Domain.Entities;

namespace SHOPRURETAIL.Application.Features.Customers.Queries
{

    public class GetSurvivorsQuery : IRequest<Response<IEnumerable<SurvivorRequestResponse>>>
    {
        
    }
    public class GetCustomerByParameterQueryHandler : IRequestHandler<GetSurvivorsQuery, Response<IEnumerable<SurvivorRequestResponse>>>
    {
        private readonly ISurvivorItemRepositoryAsync _survivorItemRepo;
        private readonly IMapper _mapper;
        public GetCustomerByParameterQueryHandler(ISurvivorItemRepositoryAsync survivorItemRepo, IMapper mapper)
        {
            _survivorItemRepo = survivorItemRepo;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<SurvivorRequestResponse>>> Handle(GetSurvivorsQuery request, CancellationToken cancellationToken)
        {

            var result=await _survivorItemRepo.GetSurvivors();
            return new Response<IEnumerable<SurvivorRequestResponse>> { Data = result };
        }
    }
}
