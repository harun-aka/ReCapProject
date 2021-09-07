using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ResponseControllerBase
    {
        private ICarImageService _carImageService;
        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }

        [HttpGet("getCarImagesByCarId")]
        public IActionResult GetCarImagesByCarId(int carId)
        {
            return ResponseResult(_carImageService.GetCarImagesByCarId(carId));
        }


        [HttpPost("add")]
        public IActionResult Add([FromForm] IFormFile imageFile, [FromForm] CarImage carImage)
        {
            return ResponseResult(_carImageService.UploadCarImage(imageFile, carImage));
        }

        [HttpPost("update")]
        public IActionResult Update(CarImage carImage)
        {
            return ResponseResult(_carImageService.Update(carImage));
        }


        [HttpDelete("delete")]
        public IActionResult Delete(CarImage carImage)
        {
            return ResponseResult(_carImageService.Delete(carImage));
        }
    }
}
