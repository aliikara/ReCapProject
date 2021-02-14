﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        
        public static string CarsListed = "Araçlar Listelendi";
        public static string BrandDeleted = "Marka Silindi";
        public static string BrandUpdated = "Marka Bilgileri Güncellendi";
        public static string BrandErrorUpdated = "Marka Bilgilerinde Güncelleme Hatası";
        public static string CarAdded = "Araç Eklendi";
        public static string CarErrorAdded = "Araç Ekleme Hatası";
        public static string CarDeleted = "Araç Silindi";
        public static string CarUpdated = "Araç Bilgileri Güncellendi";
        public static string CarErrorUpdated = "Araç Bilgilerini Güncelleme Hatası";
        public static string ColorAdded="Renk Eklendi";
        public static string ColorDeleted = "Renk Silindi";
        public static string ColorUpdated = "Renk Bilgileri Güncellendi";
        public static string BrandAdded = "Marka Eklendi";
        public static string BrandNameInvalid = "Marka İsmi Geçersiz";
        public static string CarErrorListed = "Araç Listelemesi Başarısız";
        public static string UserAdded = "Kullanıcı Eklendi";
        public static string UserDeleted = "Kullanıcı Silindi";
        public static string UserUpdated = "Kullanıcı Güncellendi";
        public static string RentSuccess = "Kiralama İşlemi Başarılı";
        public static string ReturnDateNullError = "Araç Kullanımda Kiralanamaz";
        public static string RentAddedError = "Araç Kiralama Hatası";

        public static string CustomerAdded { get; internal set; }
    }
}
