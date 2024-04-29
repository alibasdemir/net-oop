using Business.Abstracts;
using Business.Concretes;
using Business.Features.Products.Commands.Create;
using Business.Features.Products.Commands.Delete;
using Business.Features.Products.Commands.Update;
using Business.Features.Products.Queries.GetById;
using Business.Features.Products.Queries.GetList;
using Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    // api/products diye bir istek gelirse bu alttaki controller devreye girer
    [Route("api/[controller]")]     // bunlar attribute'lardır
    [ApiController]                 // bunlar attribute'lardır (aspect diye de geçer)
    public class ProductsController : ControllerBase    // ControllerBase'den türer.
    {

        // --- NOT --- ARTIK CONTROLLERIMIZIN HİÇBİR ÖZEL BİRİMLE İLETİŞİME GEÇMESİNE GEREK KALMADI. ARTIK CONTROLLER TAMAMEN MEDIATOR İLE ÇALIŞACAK...

        private readonly IMediator _mediator;   // mediatr bağımlılığı ekledik

        public ProductsController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateProductCommand command)  // KULLANICIDAN ARTIK DTO TALEP ETMEK YERİNE COMMAND'IN KENDİSİNİ TALEP EDEREK SADECE METIATOR SEN BU KOMUTU SEND ET DİYORUZ
        {
           await _mediator.Send(command);   // mediatr sen bu komutu send et
           return Created();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetListQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            GetByIdQuery query = new() { Id = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            DeleteProductCommand command = new() { Id = id };
            await _mediator.Send(command);
            return Ok("Silme işlemi başarılı");     // refactor edeceğiz
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProductCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }

    // NOT: TASK İÇİNDE IActionResult DÖNDÜĞÜMÜZDE HTTP STATUS KODLARINI VEREREK ÖRNEĞİN OK 200 VEYA ÖRNEĞİN CREATED 201 GİBİ HEM STATUS KODLARINI BELİRLEYEBİLİYORUZ HEMDE DEĞİŞKENE ATADIĞIMIZ SONUCU BODY İÇİNDE GÖREBİLİYORUZ. YUKARIDA RESULT DEĞİŞKENİNE SONUCU ATADIK VE OK 200 İÇİNDE SONUCU DÖNDÜK. BU SAYEDE BODY'DE GÖREBİLİYORUZ. VE TÜRE BAĞIMLI OLMAYIZ.
}
