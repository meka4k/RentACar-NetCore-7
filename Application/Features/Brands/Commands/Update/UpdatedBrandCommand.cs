﻿using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Commands.Update;

public class UpdatedBrandCommand:IRequest<UpdatedBrandResponse>
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public class UpdatedBrandCommandHandler : IRequestHandler<UpdatedBrandCommand, UpdatedBrandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBrandRepository _brandRepository;

        public UpdatedBrandCommandHandler(IMapper mapper, IBrandRepository brandRepository)
        {
            _mapper = mapper;
            _brandRepository = brandRepository;
        }

        public async Task<UpdatedBrandResponse> Handle(UpdatedBrandCommand request, CancellationToken cancellationToken)
        {
            Brand? brand = await _brandRepository.GetAsync(predicate: b=>b.Id == request.Id,cancellationToken:cancellationToken);
            brand =_mapper.Map(request, brand);

            await _brandRepository.UpdateAsync(brand);

            UpdatedBrandResponse response = _mapper.Map<UpdatedBrandResponse>(brand);
            return response;

        }
    }
}
