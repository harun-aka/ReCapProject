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
    }
}
