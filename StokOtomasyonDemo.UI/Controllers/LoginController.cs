using StokOtomasyonDemo.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StokOtomasyonDemo.UI.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Kullanici kul)
        {
            Kullanici kullaniciEntity = new Kullanici();

            try
            {
                using (StokEntities ctx = new StokEntities())
                {
                    var kullanici = ctx.Kullanici.Where(x => x.KullaniciAd == kul.KullaniciAd && x.Sifre == kul.Sifre).ToList();// burda select ile veritabanında eslesen verileri listeye alıyoruz. 
                    if (kullanici != null)
                    {
                        return RedirectToAction("Index", "Panel");
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return View();
        }
    }
}