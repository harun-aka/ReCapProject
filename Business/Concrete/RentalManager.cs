using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal  _rentalDal;
        ICarService _carService;

        public RentalManager(IRentalDal rentalDal, ICarService carService)
        {
            _rentalDal = rentalDal;
            _carService = carService;
        }

        public IResult Add(Rental rental)
        {
            IResult result = BusinessRules.Run(CheckCarReturned(rental.CarId));
            if (result != null)
            {
                return result;
            }
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.CarAdded);
        }

        private IResult CheckCarReturned(int carId)
        {
            var rentalCar = _rentalDal.GetRentalByCarId(carId);
            if (rentalCar.ReturnDate == null)
            {
                return new ErrorResult(Messages.CarNotReturned);
            }
            return new SuccessResult();
        }
    }
}
