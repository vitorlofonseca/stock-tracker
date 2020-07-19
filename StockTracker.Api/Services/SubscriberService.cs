using StockTracker.Api.DTOs;
using StockTracker.Domain.Builders;
using StockTracker.Domain.Entities;
using StockTraker.Infra.DAL.RepositoryInterfaces;

namespace StockTracker.Api.Services
{
    public class SubscriberService : ISubscriberService
    {
        private ISubscribersRepository _subscriberRepository;

        public SubscriberService(ISubscribersRepository subscriberRepository)
        {
            _subscriberRepository = subscriberRepository;
        }

        public Subscriber Insert(SubscriberDTO subscriberDTO)
        {
            var subscriber = SubscriberBuilder.ConstructOne()
                .WithName(subscriberDTO.Name);

            return _subscriberRepository.Insert(subscriber);
        }
    }
}
