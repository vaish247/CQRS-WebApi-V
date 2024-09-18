using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Ezzy.Website.Core.Application.Commands;
using Ezzy.Website.Infrastructure.Domain.DTO;
using Ezzy.Website.Infrastructure.Domain.Entities;
using Ezzy.Website.Infrastructure.Domain.Interfaces;
using Ezzy.Website.Infrastructure.Repository.Repositories;


namespace Ezzy.Website.Core.Application.Handlers
{
    public class AddClientItemHandler : IRequestHandler<AddClientItemCommand, ClientItemDTO>
    {
        private readonly IMapper _mapper;
        private readonly IClientItemRepository _repository;

        public AddClientItemHandler(IClientItemRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ClientItemDTO> Handle(AddClientItemCommand request, CancellationToken cancellationToken)
        {
            var item = _mapper.Map<ClientItem>(request);
            await _repository.AddClientItemAsync(item);
            return _mapper.Map<ClientItemDTO>(item);
        }
    }
}
