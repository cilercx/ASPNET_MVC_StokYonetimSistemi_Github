
using StokOtomasyonDemo.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StokOtomasyonDemo.UI.Controllers
{
    public class PanelController : Controller// sayfa ilk acıldığında paneli secersek eğer tüm hersey gözüksün.
    {
        // GET: Panel
        public ActionResult Index()
        {
            List<Urun> urunEntityList = new List<Urun>();// veri tabanından ürünleri cekip listeliyecez.

            try
            {
                using (StokEntities ctx = new StokEntities())
                {
                    urunEntityList = ctx.Urun.ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return View(urunEntityList);// veri tabanının urun tablosudan ön tarafa gönderdiğim(view=ön taraf) urunlistesi.
        }
    }
}