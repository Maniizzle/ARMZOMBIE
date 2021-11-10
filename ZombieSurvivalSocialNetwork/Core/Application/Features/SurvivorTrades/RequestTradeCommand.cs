using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ZombieSurvivalSocialNetwork.Core.Application.Exceptions;
using ZombieSurvivalSocialNetwork.Core.Application.Features.Requests;
using ZombieSurvivalSocialNetwork.Core.Application.Interfaces;
using ZombieSurvivalSocialNetwork.Core.Application.Interfaces.Repositories;
using ZombieSurvivalSocialNetwork.Core.Application.Wrappers;
using ZombieSurvivalSocialNetwork.Core.Domain.Entities;

namespace ZombieSurvivalSocialNetwork.Core.Application.Features.SurvivorTrades
{
    public class RequestTradeCommand : RequestTradeCommandRequest, IRequest<Response<object>>
    {
    }
    public class RequestTradeCommandHandler : IRequestHandler<RequestTradeCommand, Response<object>>
    {
        private readonly IGenericRepositoryAsync<Survivor> _survivorRepo;
        private readonly IGenericRepositoryAsync<Item> _itemRepo;
        private readonly IGenericRepositoryAsync<SurvivorsTrade> _survivorTradeRepo;
        private readonly ISurvivorItemRepositoryAsync _survivorItem;
        public RequestTradeCommandHandler(ISurvivorItemRepositoryAsync survivorItem,
            IGenericRepositoryAsync<Item> itemRepo,
            IGenericRepositoryAsync<SurvivorsTrade> survivorTradeRepo,
            IGenericRepositoryAsync<Survivor> survivorRepo)
        {
            _survivorItem = survivorItem;
            _itemRepo = itemRepo;
            _survivorRepo = survivorRepo;
            _survivorTradeRepo = survivorTradeRepo;
        }

        public async Task<Response<object>> Handle(RequestTradeCommand request, CancellationToken cancellationToken)
        {
            var Ids = new List<int> { request.RequestedSurviviorId, request.RequestingSurviviorId };
            var survivors = _survivorRepo.GetByParameter(c => Ids.Contains(c.Id)).ToList();
            if (survivors is null || survivors.Count < 2 ) throw new ApiException("survivor cannot be found");

            if(survivors.Any(c => c.IsInfected == true))
                throw new ApiException(" infected survivor cannot trade ");

            var itemsId = request.SurvivorsRequestResource.Select(c => c.Id).ToList();
            var items = _itemRepo.GetByParameter(c => itemsId.Contains(c.Id)).ToList();
            if (items is null || items.Count < itemsId.Count) throw new ApiException("Items dont exist");



            var survivorsWithItem=await _survivorItem.GetSurvivorItemsByIds(Ids);
            var requestingSurvivor= survivorsWithItem.Where(c=> c.SurvivorId==request.RequestingSurviviorId).ToList();
           var requestingSurvivorExistingPoints= requestingSurvivor.Sum(c => c.Count * c.Item.Point);

            //check if available point is avaliable
            var requestPointObject = items.Join(request.SurvivorsRequestResource,
                  item => item.Id,
                  request => request.Id,
                  (item, request) => new { Item = item.Name, ItemId=item.Id, Point = item.Point, Count = request.Count });
            var requestPoint= requestPointObject.Sum(c=>c.Count*c.Point);
            
            if (requestPoint < requestingSurvivorExistingPoints) throw new ApiException("You dont have enough point to make that trade");

            var requestedSurvivor = survivorsWithItem.Where(c=> c.SurvivorId==request.RequestedSurviviorId).ToList();
            for (int i = 0; i < request.SurvivorsRequestResource.Count ; i++)
            {
                for (int j = 0; j < requestedSurvivor.Count; j++)
                {
                    if(request.SurvivorsRequestResource[i].Id==requestedSurvivor[j].ItemId)
                    {
                        if (requestedSurvivor[j].Count < request.SurvivorsRequestResource[i].Count)
                            throw new ApiException($"Survivor does not have enough {requestedSurvivor[j].Item.Name}");
                    }
                }
            }

            var survivorRequest=requestPointObject.Select(c => new SurvivorsRequestAndResponseResource { ItemId = c.ItemId, Count = c.Count, Point = c.Point }).ToList();
            var trade = new SurvivorsTrade
            {
                RequestedSurvivior = request.RequestedSurviviorId,
                RequestingSurvivior = request.RequestingSurviviorId,
                SurvivorsRequestAndResponseResource = survivorRequest
            };
           await _survivorTradeRepo.AddAsync(trade);
            return new Response<object>(trade.Id);
        }
    }
}
