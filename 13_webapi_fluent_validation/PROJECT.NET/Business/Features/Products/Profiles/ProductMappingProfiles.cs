using AutoMapper;
using Business.Features.Products.Commands.Create;
using Business.Features.Products.Commands.Update;
using Business.Features.Products.Queries.GetById;
using Business.Features.Products.Queries.GetList;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Features.Products.Profiles
{
    public class ProductMappingProfiles : Profile      // iki nesne arasında mapleme yapılacak ama bu nesneleri tanımlamamız gerekiyor, hangi nesneyle hangi nesne arasında bir ilişki var. bunu yapabilmemiz için classımızı automapper'dan gelen Profile'dan inherit ediyoruz ve ctor içinde bu profil kurallarını tanımlıyoruz
    {
        public ProductMappingProfiles()
        {
            CreateMap<Product, CreateProductCommand>().ReverseMap(); // ARTIK MAPPING CreateProductCommand ile olacak o yüzden burayı güncelledik
            CreateMap<Product, GetAllProductResponse>().ReverseMap();
            CreateMap<Product, GetByIdProductResponse>().ReverseMap();
            // Update için 2 CreateMap ekliyoruz çünkü Update metodumuzda 2 tane mapleme işlemi yaptık (UpdateProductResponse ve UpdateProductCommand)
            CreateMap<Product, UpdateProductResponse>().ReverseMap();
            CreateMap<Product, UpdateProductCommand>().ReverseMap();
        }
    }
}
