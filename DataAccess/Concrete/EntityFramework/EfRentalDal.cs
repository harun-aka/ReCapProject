using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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

        public List<RentalDetailDto> GetRentalDetails()
        {
            using (SouthgateContext context = new SouthgateContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars
                             on r.CarId equals c.Id
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join cus in context.Customers
                             on r.CustomerId equals cus.Id
                             join u in context.Users
                             on cus.UserId equals u.Id
                            

                             select new RentalDetailDto
                             {
                                 BrandName = b.BrandName,
                                 FullName = u.FirstName + u.LastName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                                 
                             };
                return result.ToList();

            }
        }
    }
}
