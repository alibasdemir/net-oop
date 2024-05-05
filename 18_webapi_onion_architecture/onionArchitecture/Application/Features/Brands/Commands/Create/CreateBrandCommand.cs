using Application.Repositories;
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

            public CreateBrandCommandHandler(IBrandRepository brandRepository)
            {
                _brandRepository = brandRepository;
            }

            public async Task<CreateBrandResponse> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
            {
                Brand brand = new()
                {
                    Name = request.Name,
                };  // manuel mapping
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
