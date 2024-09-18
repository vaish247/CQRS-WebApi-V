using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Ezzy.Website.Core.Application.Commands;
using Ezzy.Website.Infrastructure.Domain.Interfaces;

namespace Ezzy.Website.Core.Application.Handlers
{
    public class DeleteClientItemHandler : IRequestHandler<DeleteClientItemCommand, bool>
    {
        private readonly IClientItemRepository _repository;

        public DeleteClientItemHandler(IClientItemRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Handle(DeleteClientItemCommand request, CancellationToken cancellationToken)
        {
            return await _repository.DeleteClientItemAsync(request.pk,request.sk);
        }
    }
}
