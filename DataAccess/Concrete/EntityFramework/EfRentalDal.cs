using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, SouthgateContext>, IRentalDal
    {
        public Rental GetRentalByCarId(int carId)
        {
            return GetAll(r => r.CarId == carId).OrderBy(r => r.Id).FirstOrDefault();
        }
    }
}
