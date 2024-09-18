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
    public class AddCaseStudyItemHandler : IRequestHandler<AddCaseStudyItemCommand, CaseStudyItemDTO>
    {
        private readonly IMapper _mapper;
        private readonly ICaseStudyItemRepository _repository;

        public AddCaseStudyItemHandler(ICaseStudyItemRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<CaseStudyItemDTO> Handle(AddCaseStudyItemCommand request, CancellationToken cancellationToken)
        {
            var item = _mapper.Map<CaseStudyItem>(request);
            await _repository.AddCaseStudyItemAsync(item);
            return _mapper.Map<CaseStudyItemDTO>(item);
        }
    }
}
