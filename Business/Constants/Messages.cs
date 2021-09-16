using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
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


        public static string CarImagesListed = "Resimler listelendi.";
        public static string CarImageLimitExceded = "En Fazla 5 Resim yüklenebilir.";
        public static string CarImageAdded = "Ürün Resmi eklendi.";
        public static string CarImageDeleted = "Ürün Resmi silindi.";
        public static string CarImageUpdated = "Ürün Resmi güncellendi.";


        public static string RentalAdded = "Kiralandı.";
        public static string RentalUpdated = "Kiralık Araba güncellendi.";


        public static string AuthorizationDenied = "Erişim reddedildi.";
        public static string UserAlreadyExists = "Kullanıcı zaten var.";
        public static string AccessTokenCreated = "Access token created";
        public static string SuccessfulLogin = "Başarılı giriş.";
        public static string PasswordError = "Şifre hatası.";
        public static string UserNotFound = "Kullanıcı bulunamadı.";
        public static string UserRegistered = "Kullanıcı kaydedildi.";
        public static string RentalsListed = "Kiralıklar listelendi.";
        public static string Rentaladded = "Kiralık eklendi.";
    }
}
