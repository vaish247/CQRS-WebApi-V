using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using CQRS_WebApi_V1.Application.Commands;
using CQRS_WebApi_V1.Domain.DTO;
using CQRS_WebApi_V1.Domain.Entities;
using CQRS_WebApi_V1.Domain.Interfaces;


namespace CQRS_WebApi_V1.Application.Handlers
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
