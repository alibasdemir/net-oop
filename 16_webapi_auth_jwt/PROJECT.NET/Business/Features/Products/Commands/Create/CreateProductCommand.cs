using AutoMapper;
using Business.Abstracts;
using Core.Application.Pipelines.Logging;
using Core.CrossCuttingConcerns.Exceptions.Types;
using DataAccess.Abstracts;
using Entities;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationException = Core.CrossCuttingConcerns.Exceptions.Types.ValidationException;

namespace Business.Features.Products.Commands.Create
{
    public class CreateProductCommand : IRequest<CreateProductResponse>, ILoggableRequest  // Command'lar her zaman mediatr'dan gelen IRequest gönderir --> Komutun tanımı  --- NOT --- ILoggableRequest EKLEDİK. YANİ ARTIK SADECE BU KISIMDA LOGLAMA ÇALIŞACAK. BUNU EKLEMESEYDİK LOGLAMA ÇALIŞMAYACAKTI ÇÜNKÜ ILoggableRequest OLUŞTURDUK VE LOGLAMANIN ÇALIŞACAĞI YERLERİ İMZALAMAK İÇİN BU INTERFACE'I KULLANDIK. LoggingBehavior'da bunu belirttik.
    {
        // Komut dediğimiz şey aslında bir nevi DTO'dur ve bizim ek bir DTO oluşturmamız gerekmez ve biz komutu direkt belirleriz. Çünkü kullanıcı bir komut gönderiyorsa bilgileri de gönderir
        public string Name { get; set; }
        public double UnitPrice { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }

        public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreateProductResponse>    // Komutu handler edecek sağlayıcının tanımı.. IRequestHandler hangi komutu handler edeceğinin bilgisini ister yani CreateProductCommand
        {

            // DEPENDENCY'LERİ BURAYA YAZIYORUZ
            private readonly IProductRepository _productRepository;      // dependency ekledikten sonra constructor oluşturmayı unutmuyoruz
            private readonly ICategoryService _categoryService;         // categoryid içerdiği için categoryservice dependency ediyoruz
            private readonly IMapper _mapper;

            public CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper, ICategoryService categoryService)    // DEPENDENCY SONRASI OLUŞTURDUĞUMUZ CONSTRUCTOR
            {
                _productRepository = productRepository;
                _mapper = mapper;
                _categoryService = categoryService;
            }


            public async Task<CreateProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)       // --> varsayılan olarak asenkron çalışır. ama await keyword'ünü kullanabilmek için async ile imzalamayı unutmuyoruz
            {
                // BURADA YER ALAN IValidator KISMINI SİLDİK. ARTIK HİÇBİR KOMUTUN İÇİNDE VALIDATOR'LERİ BUL, ONLARI NEW'LE, SONUCU KONTROL ET GİBİ YAPIYA İHTİYACIMIZ YOK. ÇÜNKÜ Business katmanına FluentValidation.DependencyInjectionExtensions paketini kurduk böylece ne kadar validasyon varsa hepsini tara ve bunu servislerin içine ekle demiş olduk. Ve core katmanındaki ValidationBehavior içine gerekli tanımlamaları ekledik.

                Product? productWithSameName = await _productRepository.GetAsync(p => p.Name == request.Name);
                if (productWithSameName is not null)
                {
                    throw new System.Exception("Aynı isimde 2. ürün eklenemez");
                }

                // KATEGORİ VERİLERİNE ULAŞMAK
                Category? category = await _categoryService.GetByIdAsync(request.CategoryId);
                if (category is null)
                    throw new BusinessException("Böyle bir kategori bulunamadı.");

                Product product = _mapper.Map<Product>(request);
                await _productRepository.AddAsync(product);

                CreateProductResponse response = _mapper.Map<CreateProductResponse>(product);
                return response;
            }
        }
    }
}
