using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Features.Products.Commands.Create
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>    // CreateProductCommandValidator sınıfını AbstractValidator olarak belirleyip valide edeceği sınıfı içerisine yazıyoruz
    {
        public CreateProductCommandValidator()      // kuralları boş constructor içinde tanımlıyoruz
        {
            RuleFor(i => i.Name).NotEmpty().WithMessage("İsim alanı asla ve asla boş olamaz");        // İsim alanı boş olamaz kuralı ekledik. Ayrıca bu mesajlar FluentValidation'da otomatik olarak default geliyor ancak biz bu mesajları ezebiliyoruz. WithMessage yazıp içine istediğimiz mesajı yazıyoruz.
            RuleFor(i => i.Stock).GreaterThanOrEqualTo(1);      // Stok 1'den büyük veya 1'e eşit olmalı kuralı
            RuleFor(i => i.UnitPrice).GreaterThanOrEqualTo(1);  // UnitPrice 1'den büyük veya 1'e eşit olmalı kuralı
            RuleFor(i => i.CategoryId).GreaterThanOrEqualTo(1); // CategoryId 1'den büyük veya 1'e eşit olmalı kuralı



            // FluentValidation'ın hazır kuralları haricinde kendi belirlediğimiz kurallarımızı da yazabiliriz:
            RuleFor(i => i.Name).Must(name => name.StartsWith("A"));    // Örneğin name alanı A harfi ile başlasın kuralı. Bunu lambda expression şeklinde yazdık veya bir fonksiyon referansı olarakta yazabiliriz. Fonskiyonu altta yazdık
            // RuleFor(i => i.Name).Must(StartsWithA);      // ---> fonksiyonu altta tanımladık ve referansını geçtik
        }

        //public bool StartsWithA(string name)
        //{
        //    return name.StartsWith("A");
        //}
    }
}
