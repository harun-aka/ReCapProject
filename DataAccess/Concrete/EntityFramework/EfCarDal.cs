using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, SouthgateContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (SouthgateContext context = new SouthgateContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join co in context.Colors
                             on c.ColorId equals co.Id

                             select new CarDetailDto
                             {
                                 CarId = c.Id,
                                 BrandId = b.Id,
                                 ColorId = co.Id,
                                 BrandName=b.BrandName,
                                 CarName=c.CarName,
                                 ColorName=co.ColorName,
                                 DailyPrice=c.DailyPrice,
                                 Description=c.Description,
                                 ModelYear=c.ModelYear
                             };
                return result.ToList();

            }
        }

        public CarImageDetailDto GetCarImageDetails(int carId)
        {
            using (SouthgateContext context = new SouthgateContext())
            {
                var images = from ci in context.CarImages
                             where ci.CarId == carId

                             select new CarImage
                             {
                                 Id = ci.Id,
                                 CarId = ci.CarId,
                                 Date = ci.Date,
                                 ImagePath = ci.ImagePath
                             };

                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join co in context.Colors
                             on c.ColorId equals co.Id
                             where c.Id == carId

                             select new CarImageDetailDto
                             {
                                 BrandName = b.BrandName,
                                 CarName = c.CarName,
                                 ColorName = co.ColorName,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 ModelYear = c.ModelYear,
                                 CarImages = images.ToList()
                             };

                return result.FirstOrDefault();

            }
        }

    }
}
