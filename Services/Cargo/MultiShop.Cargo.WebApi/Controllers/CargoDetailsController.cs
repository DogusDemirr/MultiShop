﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCompanyDtos;
using MultiShop.Cargo.DtoLayer.Dtos.CargoDetailDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoDetailsController : ControllerBase
    {
        private readonly ICargoDetailService _cargoDetailService;

        public CargoDetailsController(ICargoDetailService cargoDetailService)
        {
            _cargoDetailService = cargoDetailService;
        }

        [HttpGet]
        public IActionResult CargoDetailList()
        {
            var values = _cargoDetailService.TGetAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateCargoDetail(CreateCargoDetailDto createCargoDetailDto)
        {
            CargoDetail cargoDetail = new CargoDetail()
            {
               Barcode = createCargoDetailDto.Barcode,
               ReceiverCustomer = createCargoDetailDto.ReceiverCustomer,
               SenderCustomer = createCargoDetailDto.SenderCustomer,
               CargoCompanyId = createCargoDetailDto.CargoCompanyId,
            };

            _cargoDetailService.TInsert(cargoDetail);
            return Ok("Kargo detayı başarıyla oluşturuldu");
        }

        [HttpDelete]
        public IActionResult RemoveCargoDetail(int id)
        {
            _cargoDetailService.TDelete(id);
            return Ok("Kargo detayı başarıyla silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoDetailById(int id)
        {
            var values = _cargoDetailService.TGetById(id);
            return Ok(values);
        }

        [HttpPut]
        public IActionResult UpdateCargoDetail(UpdateCargoDetailDto updateCargoDetailDto)
        {
            CargoDetail cargoDetail = new CargoDetail()
            {
               CargoCompanyId = updateCargoDetailDto.CargoCompanyId,
               Barcode = updateCargoDetailDto.Barcode,
               CargoDetailId = updateCargoDetailDto.CargoDetailId,
               ReceiverCustomer = updateCargoDetailDto.ReceiverCustomer,
               SenderCustomer= updateCargoDetailDto.SenderCustomer,
            };
            _cargoDetailService.TUpdate(cargoDetail);
            return Ok("Kargo detayı başarıyla güncellendi");
        }
    }
}
