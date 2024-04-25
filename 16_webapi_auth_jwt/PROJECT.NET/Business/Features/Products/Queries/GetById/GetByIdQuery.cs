using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.Types;
using DataAccess.Abstracts;
using Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Features.Products.Queries.GetById
{
    public class GetByIdQuery : IRequest<GetByIdProductResponse>
    {
        public int Id { get; set; }     // BU KISIMA İSTEKTEN ALINACAK VERİ YAZILIR. İSTEKTEN GÖNDERİLECEK CEVAP (NAME, FİYAT GİBİ) BURAYA YAZILMAZ. KISACA BURAYA ÜRÜNÜ GETİRMEK İÇİN İSTEDİĞİMİZ VERİLERİ YAZARIZ. YANİ KULLANICI ID NUMARASINI YAZSIN EXECUTE ETSİN VE VERİLER GELSİN.

        // İSTEKTEN GÖNDERİLECEK CEVAP GetByIdProductResponse KISMINA YANİ DTO'YA YAZILIR (HANGİ ALANLARI GÖRECEĞİ ---> ÖRNEĞİN; ID, NAME, PRICE, STOCK VS GİBİ)

        public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, GetByIdProductResponse>
        {
            // DEPENDENCY'LERI TANIMLAMAYI UNUTMUYORUZ:
            private readonly IProductRepository _productRepository;
            private readonly IMapper _mapper;

            public GetByIdQueryHandler(IMapper mapper, IProductRepository repository)
            {
                _mapper = mapper;
                _productRepository = repository;
            }

            public async Task<GetByIdProductResponse> Handle(GetByIdQuery request, CancellationToken cancellationToken)
            {
                Product? product = await _productRepository.GetAsync(p => p.Id == request.Id);

                if (product is null)
                    throw new BusinessException("Böyle bir ürün bulunamadı");

                GetByIdProductResponse response = _mapper.Map<GetByIdProductResponse>(product);

                return response;
            }
        }
    }
}
