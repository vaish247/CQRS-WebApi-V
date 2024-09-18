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
    public class AddCompanyItemHandler : IRequestHandler<AddCompanyItemCommand, CompanyItemDTO>
    {
        private readonly IMapper _mapper;
        private readonly ICompanyItemRepository _repository;

        public AddCompanyItemHandler(ICompanyItemRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<CompanyItemDTO> Handle(AddCompanyItemCommand request, CancellationToken cancellationToken)
        {
            var item = _mapper.Map<CompanyItem>(request);
            await _repository.AddCompanyItemAsync(item);
            return _mapper.Map<CompanyItemDTO>(item);
        }
    }
}
