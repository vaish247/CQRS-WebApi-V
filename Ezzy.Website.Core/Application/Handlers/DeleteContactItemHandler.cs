using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Ezzy.Website.Core.Application.Commands;
using Ezzy.Website.Infrastructure.Domain.Interfaces;

namespace Ezzy.Website.Core.Application.Handlers
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
