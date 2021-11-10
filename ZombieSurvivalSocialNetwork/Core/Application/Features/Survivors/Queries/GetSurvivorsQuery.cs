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
using ZombieSurvivalSocialNetwork.Core.Application.Wrappers;
using ZombieSurvivalSocialNetwork.Core.Domain.Entities;

namespace SHOPRURETAIL.Application.Features.Customers.Queries
{

    public class GetSurvivorsQuery : IRequest<Response<IEnumerable<object>>>
    {
        
    }
    public class GetCustomerByParameterQueryHandler : IRequestHandler<GetSurvivorsQuery, Response<IEnumerable<object>>>
    {
        private readonly IGenericRepositoryAsync<SurvivorItem> _survivorItem;
        private readonly IMapper _mapper;
        public GetCustomerByParameterQueryHandler(IGenericRepositoryAsync<SurvivorItem> survivorItem, IMapper mapper)
        {
            _survivorItem = survivorItem;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<object>>> Handle(GetSurvivorsQuery request, CancellationToken cancellationToken)
        {

            var survivorsWithItem = (await _survivorItem.GetAllAsync())
                .GroupBy(c => c.SurvivorId)
                .Select(c=> 
                new 
                {
                    SurvivorId = c.Key,
                    SurvivorItems = c.AsEnumerable()
                }
                ).ToList();
           

            return new Response<IEnumerable<object>> { Data = survivorsWithItem };
        }
    }
}
