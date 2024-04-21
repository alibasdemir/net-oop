using AutoMapper;
using Business.Abstracts;
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
    public class CreateProductCommand : IRequest  // Command'lar her zaman mediatr'dan gelen IRequest gönderir --> Komutun tanımı
    {
        // Komut dediğimiz şey aslında bir nevi DTO'dur ve bizim ek bir DTO oluşturmamız gerekmez ve biz komutu direkt belirleriz. Çünkü kullanıcı bir komut gönderiyorsa bilgileri de gönderir
        public string Name { get; set; }
        public double UnitPrice { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }

        public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>    // Komutu handler edecek sağlayıcının tanımı.. IRequestHandler hangi komutu handler edeceğinin bilgisini ister yani CreateProductCommand
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


            public async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)       // --> varsayılan olarak asenkron çalışır. ama await keyword'ünü kullanabilmek için async ile imzalamayı unutmuyoruz
            {
                // PRODUCTMANAGER'DAKİ Add methodu içindekileri aldık ve dto olan yerleri artık request yapıyoruz

                IValidator<CreateProductCommand> validator = new CreateProductCommandValidator();   // fluent validationı entegre ediyoruz
                
                // validator.ValidateAndThrow(request);    // kendi exception'ınını fırlatacak. ama biz bunu istemiyoruz. bu void olduğu için bunu değişken içine alamıyoruz

                ValidationResult result = validator.Validate(request);    // validation'ı yapacak ve sonucu verecek. --> Sen bana sonucu ver ben bu sonucun durumunu kontrol edeyim eğer bu sonuç valid değilse kendi exception'ınımı fırlatayım. Core katmanında Exceptions içinde ValidationException'ımız vardı onu kullanıyoruz:
                if (!result.IsValid)
                {
                    throw new ValidationException(result.Errors.Select(i=>i.ErrorMessage).ToList());
                }

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
            }
        }
    }
}
