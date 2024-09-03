using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Ezzy.Website.Core.Application.Commands;
using Ezzy.Website.Infrastructure.Domain.DTO;
using Ezzy.Website.Infrastructure.Domain.Entities;
using Ezzy.Website.Infrastructure.Domain.Interfaces;


namespace Ezzy.Website.Core.Application.Handlers
{
    public class AddContactItemHandler : IRequestHandler<AddContactItemCommand, ContactItemDTO>
    {
        private readonly IMapper _mapper;
        private readonly IContactItemRepository _repository;

        public AddContactItemHandler(IContactItemRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ContactItemDTO> Handle(AddContactItemCommand request, CancellationToken cancellationToken)
        {
            var item = _mapper.Map<ContactItem>(request);
            await _repository.AddContactItemAsync(item);
            return _mapper.Map<ContactItemDTO>(item);
        }
    }
}
