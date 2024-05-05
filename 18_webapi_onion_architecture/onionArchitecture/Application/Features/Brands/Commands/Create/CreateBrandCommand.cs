using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Commands.Create
{
    public class CreateBrandCommand : IRequest<CreateBrandResponse>
    {
        public string Name { get; set; }

        public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, CreateBrandResponse>
        {
            private readonly IBrandRepository _brandRepository;
            private readonly IMapper _mapper;

            public CreateBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper)
            {
                _brandRepository = brandRepository;
                _mapper = mapper;
            }

            public async Task<CreateBrandResponse> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
            {
                Brand brand = _mapper.Map<Brand>(request);  // auto mapping
                await _brandRepository.AddAsync(brand);
                return new CreateBrandResponse()
                {
                    Id = brand.Id,
                    Name = brand.Name
                };

            }
        }
    }
}
