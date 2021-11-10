using AutoMapper;
using MediatR;
using System.Threading;
using System.Linq;
using System.Threading.Tasks;
using SHOPRURETAIL.Application.Requests;
using ZombieSurvivalSocialNetwork.Core.Application.Wrappers;
using ZombieSurvivalSocialNetwork.Core.Application.Exceptions;
using ZombieSurvivalSocialNetwork.Core.Domain.Entities;
using ZombieSurvivalSocialNetwork.Core.Application.Interfaces;
using ZombieSurvivalSocialNetwork.Core.Application.Extensions;

namespace ZombieSurvivalSocialNetwork.Core.Application.Features.Survivors.Commands

{
    public partial class AddSurvivorCommand : AddSurvivorCommandRequest, IRequest<Response<object>>
    {
        
    }
    public class AddSurvivorCommandHandler : IRequestHandler<AddSurvivorCommand, Response<object>>
    {
        private readonly IGenericRepositoryAsync<Survivor> _survivorRepo;
        private readonly IGenericRepositoryAsync<Item> _itemRepo;
        public AddSurvivorCommandHandler(IGenericRepositoryAsync<Item> itemRepo,IGenericRepositoryAsync<Survivor> survivorRepo)
        {
            _itemRepo = itemRepo;
            _survivorRepo = survivorRepo;
        }

        public async Task<Response<object>> Handle(AddSurvivorCommand request, CancellationToken cancellationToken)
        {
            var resourceIds = request.Resources.Select(c => c.Id);
            var resources = _itemRepo.GetByParameter(c => resourceIds.Contains(c.Id)).ToList();
            if (resources is null || resources.Count < 4) throw new ApiException("Kindly fill all resources");

            var survivorItems=resources.Join(request.Resources, item => item.Id, resource => resource.Id, (item, resource) => new SurvivorItem { ItemId = item.Id, Count = resource.Count }).ToList();
            var lastlocation = $"{request.LastLocationLatitude},{request.LastLocationLongitude}";
            var survivor = new Survivor
            {
                Age = request.Age,
                FirstName = request.FirstName,
                Gender = request.Gender.ToUpper().ConvertToGender(),
                LastLocation = lastlocation,
                LastName = request.LastName,
                SurvivorItems = survivorItems
            };
            await _survivorRepo.AddAsync(survivor);
            return new Response<object>(survivor);
        }
    }
}
