using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IResult Add(CarImage carImage)
        {
            
            IResult result = BusinessRules.Run(CheckCarImageCountCorrect(carImage.CarId));
            if (result != null)
            {
                return result;
            }
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);
        }

        public IResult Delete(CarImage carImage)
        {
            var result = ImageFileHelper.Delete(carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarImageDeleted);
        }

        public IDataResult<List<CarImage>> GetCarImagesByCarId(int carId)
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(p => p.CarId == carId), Messages.CarImagesListed);
        }

        public IResult Update(CarImage carImage)
        {
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImageUpdated);
        }

        private IResult CheckCarImageCountCorrect(int carId)
        {
            var carImageCount = GetCarImagesByCarId(carId).Data.Count();
            if (carImageCount >= 5)
            {
                return new ErrorResult(Messages.CarImageLimitExceded);
            }
            return new SuccessResult();
        }

        public IResult SetDefaultCarImage(int carId)
        {
            var carImageCount = GetCarImagesByCarId(carId).Data.Count();
            if (carImageCount == 0)
            {
                CarImage carImage = new CarImage
                {
                    CarId = carId,
                    ImagePath = "..."
                };

               return Add(carImage);
            }
            return new ErrorResult();
        }

        public IResult UploadCarImage(IFormFile imageFile, CarImage carImage)
        {
            var result = BusinessRules.Run(CheckCarImageCountCorrect(carImage.CarId));
            if (result != null)
            {
                return result;
            }


            string filePath = ImageFileHelper.Upload(imageFile);
            carImage.ImagePath = filePath;
            return this.Add(carImage);
        }
    }
}
