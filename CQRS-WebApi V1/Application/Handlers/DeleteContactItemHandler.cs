using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using CQRS_WebApi_V1.Application.Commands;
using CQRS_WebApi_V1.Domain.Interfaces;

namespace CQRS_WebApi_V1.Application.Handlers
{
    public class DeleteContactItemHandler : IRequestHandler<DeleteContactItemCommand, bool>
    {
        private readonly IContactItemRepository _repository;

        public DeleteContactItemHandler(IContactItemRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Handle(DeleteContactItemCommand request, CancellationToken cancellationToken)
        {
            return await _repository.DeleteContactItemAsync(request.Id);
        }
    }
}
