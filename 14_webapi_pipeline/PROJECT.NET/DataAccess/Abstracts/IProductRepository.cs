﻿using Core.DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstracts
{
    public interface IProductRepository : IRepository<Product>, IAsyncRepository<Product>     // Ne için çalışıyorsa onu veriyoruz. Burada <Product> Yani IRepository'de bulunan <T> => <Product> olacak şekilde oluşmuş oldu.
    {
        // BURADA BULUNAN YAPIMIZI SİLDİK VE OLUŞTURDUĞUMUZ CORE KATMANINDAKİ IRepository'deki generic yapıyı kullanıyoruz. (Miras alarak) Core paketini referans vermeyi unutmuyoruz.

        // AYRICA ÖZEL METODLAR YİNE BURADA İMPLEMENTE EDİLEBİLİR.

        // ÖNEMLİ NOT: PEKİ NEDEN EfProductRepository'i de bu şekilde IRepository<Product>'den miras almadık diye soracak olursak çünkü bir üstte belirttiğimiz gibi burada özel metodlar implemente edilmiş olabilir ve IRepository ortak alanları aldığı için direkt onu miras almak doğru bir yaklaşım olmaz. Burada yer alabilecek olan özel metodların da miras alınabilmesi için EfProductRepository'de burayı yani IProductRepository'i miras almak en doğru yoldur.
        // Ayrıca bahsettiğimiz bu iki dosya IRepository'i miras alınırsa Program.cs içine kaydederken hata alırız. (AddSingleton kısmı) Yani aynı interfaceden türediği için iki tane bağımlılık ekleyemeyiz
    }
}