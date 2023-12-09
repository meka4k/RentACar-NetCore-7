using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Queries.GetById;

public class GetByIdQuery:IRequest<GetByIdBrandResponse>
{
    public Guid Id { get; set; }

    public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, GetByIdBrandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBrandRepository _brandRepository;

        public GetByIdQueryHandler(IMapper mapper, IBrandRepository brandRepository)
        {
            _mapper = mapper;
            _brandRepository = brandRepository;
        }

        public async Task<GetByIdBrandResponse> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            Brand? brand = await _brandRepository.GetAsync(predicate:b=>b.Id == request.Id,cancellationToken:cancellationToken,withDeleted:true);

           GetByIdBrandResponse byIdBrandResponse=  _mapper.Map<GetByIdBrandResponse>(brand);

            return byIdBrandResponse;
        }
    }
}
