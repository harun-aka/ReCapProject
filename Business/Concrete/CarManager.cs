using Business.Abstract;
using Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.DTOs;
using Core.Utilities.Results;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Business.BusinessAspects.Autofac;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [ValidationAspect(typeof(CarValidator))]
        [SecuredOperation("admin")]
        public IResult Add(Car car)
        {  
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        //[SecuredOperation("admin")]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsListed);            
        }

        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == carId), Messages.CarsListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails(int? brandId, int? colorId)
        {
            if (brandId.HasValue & colorId.HasValue)
                return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails().Where(c => c.BrandId == brandId & c.ColorId == colorId).ToList(), Messages.CarsListed);
            else if (brandId.HasValue)
                return GetCarsByBrandId(brandId.Value);
            else if (colorId.HasValue)
                return GetCarsByColorId(colorId.Value);
            else
                return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), Messages.CarsListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails().Where(c => c.BrandId == brandId).ToList(), Messages.CarsListed);   
        }

        public IDataResult<List<CarDetailDto>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails().Where(c => c.ColorId == colorId).ToList(), Messages.CarsListed); 
        }

        public IDataResult<List<CarDetailDto>> GetCarsByBrandIdAndColorId(int? brandId, int? colorId)
        {
            if (brandId.HasValue & colorId.HasValue)
                return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails().Where(c => c.BrandId == brandId & c.ColorId == colorId).ToList(), Messages.CarsListed);
            else if (brandId.HasValue)           
                return GetCarsByBrandId(brandId.Value);         
            else  
                return GetCarsByColorId(colorId.Value);                    
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }

        public IDataResult<CarImageDetailDto> GetCarImageDetails(int carId)
        {
            return new SuccessDataResult<CarImageDetailDto>(_carDal.GetCarImageDetails(carId), Messages.CarListed);
        }
    }
}
