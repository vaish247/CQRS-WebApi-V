using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Ezzy.Website.Core.Application.Commands;
using Ezzy.Website.Infrastructure.Domain.Interfaces;

namespace Ezzy.Website.Core.Application.Handlers
{
    public class DeleteCompanyItemHandler : IRequestHandler<DeleteCompanyItemCommand, bool>
    {
        private readonly ICompanyItemRepository _repository;

        public DeleteCompanyItemHandler(ICompanyItemRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Handle(DeleteCompanyItemCommand request, CancellationToken cancellationToken)
        {
            return await _repository.DeleteCompanyItemAsync(request.pk,request.sk);
        }
    }
}
