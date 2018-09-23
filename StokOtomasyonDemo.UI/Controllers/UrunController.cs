using StokOtomasyonDemo.UI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StokOtomasyonDemo.UI.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(UrunModel urunmodel)//burdaki oluşturulan class
        {
            Urun urunEntity = new Urun();// burdaki veritabanı nesnesi(classta oluşturulan veritabanına gönderiyoruz.)

            try
            {
                using (StokEntities ctx = new StokEntities())
                {
                    urunEntity.Ad = urunmodel.Ad;
                    urunEntity.Adet = urunmodel.Adet;
                    urunEntity.AlisFiyat = urunmodel.AlisFiyat;
                    urunEntity.SatisFiyat = urunmodel.SatisFiyat;
                    urunEntity.Kdv = urunmodel.Kdv;
                    urunEntity.MarkaID = 2;
                    urunEntity.EklenmeTarihi = DateTime.Now;

                    ctx.Urun.Add(urunEntity);
                    ctx.SaveChanges();
                }
            }

            catch (Exception)
            {

                throw;
            }

            return View();

        }


        [HttpGet]
        public ActionResult Guncelle(int id)
        {

            UrunModel malzemeClass = new UrunModel();
            Urun malzemeEntity = new Urun();

            try
            {
                using (StokEntities ctx = new StokEntities())
                {
                    malzemeEntity = ctx.Urun.Where(x => x.ID == id).FirstOrDefault();
                    malzemeClass.Id = malzemeEntity.ID;
                    malzemeClass.Ad = malzemeEntity.Ad;
                    malzemeClass.Adet = malzemeEntity.Adet;
                    malzemeClass.AlisFiyat = malzemeEntity.AlisFiyat;
                    malzemeClass.Kdv= malzemeEntity.Kdv;
                    malzemeClass.SatisFiyat = malzemeEntity.SatisFiyat;

                }
            }
            catch (Exception)
            {

                throw;
            }

            return View(malzemeClass);
        }

        [HttpPost]
        public ActionResult Guncelle(UrunModel urunclass)
        {
            Urun urunEntity = new Urun();           

            try
            {
                using (StokEntities ctx = new StokEntities())
                {
                    urunEntity = ctx.Urun.Where(x => x.ID == urunclass.Id).FirstOrDefault();
                    urunEntity.Ad = urunclass.Ad;
                    urunEntity.Adet = urunclass.Adet;
                    urunEntity.AlisFiyat = urunclass.AlisFiyat;
                    urunEntity.Kdv = urunclass.Kdv;
                    urunEntity.SatisFiyat = urunclass.SatisFiyat;
                    ctx.Entry(urunEntity).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return RedirectToAction("Index", "Panel");
        }


        [HttpGet]
        public ActionResult Sil(int id)
        {
            UrunModel malzemeClass = new UrunModel();
            Urun malzemeEntity = new Urun();

            try
            {
                using (StokEntities ctx = new StokEntities())
                {
                    malzemeEntity = ctx.Urun.Where(x => x.ID ==id).FirstOrDefault();                   
                    malzemeClass.Ad = malzemeEntity.Ad;
                    malzemeClass.Adet = malzemeEntity.Adet;
                    malzemeClass.AlisFiyat = malzemeEntity.AlisFiyat;
                    malzemeClass.Kdv = malzemeEntity.Kdv;
                    malzemeClass.SatisFiyat = malzemeEntity.SatisFiyat;

                }
            }
            catch (Exception)
            {

                throw;
            }


            return View(malzemeClass);
        }

        [HttpPost]
        public ActionResult Sil(UrunModel urunclass)
        {
            Urun urunEntity = new Urun();
            Satis satisEntity = new Satis();
            try
            {
                using (StokEntities ctx = new StokEntities())
                {
                    urunEntity = ctx.Urun.ToList().Where(x => x.ID ==urunclass.Id).FirstOrDefault();
                    satisEntity = ctx.Satis.ToList().Where(x => x.UrunID == urunclass.Id).FirstOrDefault();
                    ctx.Urun.Remove(urunEntity);
                    ctx.Satis.Remove(satisEntity);
                    ctx.SaveChanges();

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return RedirectToAction("Index","Panel");//urunu en son listeli görmek için bu sayfaya yönlendiririz.
        }

    }
}
