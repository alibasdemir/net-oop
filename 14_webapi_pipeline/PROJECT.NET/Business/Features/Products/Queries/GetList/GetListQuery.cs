using AutoMapper;
using DataAccess.Abstracts;
using Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Features.Products.Queries.GetList
{
    public class GetListQuery : IRequest<List<GetAllProductResponse>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }

        public class GetListQueryHandler : IRequestHandler<GetListQuery, List<GetAllProductResponse>>  // handler da içerisine handle edeceği command ya da query'i ve varsa dönüş tipini alır.
        {
            private readonly IProductRepository _productRepository;
            private readonly IMapper _mapper;

            public GetListQueryHandler(IProductRepository productRepository, IMapper mapper)
            {
                _productRepository = productRepository;
                _mapper = mapper;
            }

            public async Task<List<GetAllProductResponse>> Handle(GetListQuery request, CancellationToken cancellationToken)
            {
                List<Product> products = await _productRepository.GetListAsync();

                List<GetAllProductResponse> response = _mapper.Map<List<GetAllProductResponse>>(products);
                return response;
            }
        }
    }
}
