using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Ürün eklendi.";  //public değişkenler büyük harfle yazılır.
        public static string CarNameInvalid = "Ürün ismi geçersiz.";

        public static string CarUpdated = "Ürün güncellendi.";
        public static string CarDeleted = "Ürün silindi.";

        public static string MaintenanceTime = "Sistem bakımda.";
        public static string CarsListed = "Ürün listelendi.";

        public static string CarDailyPriceInvalid = "Araba fiyatı sıfırdan büyük olmalıdır.";
        public static string CarNotReturned = "Araba daha teslim edilmedi.";
    }
}
