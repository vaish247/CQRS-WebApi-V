using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Ezzy.Website.Core.Application.Commands;
using Ezzy.Website.Infrastructure.Domain.Interfaces;

namespace Ezzy.Website.Core.Application.Handlers
{
    public class DeleteCaseStudyItemHandler : IRequestHandler<DeleteCaseStudyItemCommand, bool>
    {
        private readonly ICaseStudyItemRepository _repository;

        public DeleteCaseStudyItemHandler(ICaseStudyItemRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Handle(DeleteCaseStudyItemCommand request, CancellationToken cancellationToken)
        {
            return await _repository.DeleteCaseStudyItemAsync(request.pk,request.sk);
        }
    }
}
