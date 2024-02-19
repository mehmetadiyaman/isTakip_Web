using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcFirmaCagri.Models.Entitiy;


namespace MvcFirmaCagri.Controllers
{
	[Authorize]
	public class DefaultController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		DbisTAKİPEntities db = new DbisTAKİPEntities();
		public ActionResult AktifCagrilar()
		{
			var mail = (string)Session["mail"];
			var id=db.tblFirmalar.Where(x=>x.mail==mail).Select(y=>y.ID).FirstOrDefault();
			var cagrilar = db.tblCagrilar.Where(x => x.Durum == true && x.CagriFirma==id).ToList();
			return View(cagrilar);
		}
		public ActionResult PasifCagrilar()
		{
			var mail = (string)Session["mail"];
			var id = db.tblFirmalar.Where(x => x.mail == mail ).Select(y => y.ID).FirstOrDefault();
			var cagrilar = db.tblCagrilar.Where(x => x.Durum == false && x.CagriFirma == id).ToList();
			return View(cagrilar);
		}
		[HttpGet]
		public ActionResult YeniCagri()
		{
			return View();
		}
		[HttpPost]
		public ActionResult YeniCagri(tblCagrilar p)
		{
			var mail = (string)Session["mail"];
			var id = db.tblFirmalar.Where(x => x.mail == mail).Select(y => y.ID).FirstOrDefault();
			p.Durum = true;
			p.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
			p.CagriFirma = id;
			db.tblCagrilar.Add(p);
			db.SaveChanges();
			return RedirectToAction("AktifCagrilar");
		}
		public ActionResult CagriDetay(int id)
		{
			var cagri = db.tblCagriDetay.Where(x => x.Cagri == id).ToList();
			return View(cagri);
		}
		public ActionResult CagriGetir(int id)
		{
			var cagri = db.tblCagrilar.Find(id);
			return View("CagriGetir", cagri);
		}
		public ActionResult CagriDuzenle(tblCagrilar p)
		{
			var cagri = db.tblCagrilar.Find(p.ID);
			cagri.Konu = p.Konu;
			cagri.Aciklama = p.Aciklama;
			db.SaveChanges();
			return RedirectToAction("AktifCagrilar");
		}
        [HttpGet]
        public ActionResult ProfilDuzenle()
        {
            var mail = (string)Session["mail"];
            var id = db.tblFirmalar.Where(x => x.mail == mail).Select(y => y.ID).FirstOrDefault();
            var profil = db.tblFirmalar.Where(x => x.ID == id).FirstOrDefault();
            if (string.IsNullOrEmpty(profil.Sifre))
            {
                var existingSifre = db.tblFirmalar.Where(x => x.ID == id).Select(y => y.Sifre).FirstOrDefault();
                profil.Sifre = existingSifre;
            }

            return View(profil);
        }

        [HttpPost]
        public ActionResult ProfilGuncelle(tblFirmalar firma)
        {
            if (ModelState.IsValid)
            {
                var existingFirma = db.tblFirmalar.Find(firma.ID);
                if (existingFirma != null)
                {
                    if (string.IsNullOrEmpty(firma.Sifre))
                    {
                        firma.Sifre = existingFirma.Sifre;
                    }

                    existingFirma.Ad = firma.Ad;
                    existingFirma.Yetkili = firma.Yetkili;
                    existingFirma.Sifre = firma.Sifre;
                    existingFirma.Sektor = firma.Sektor;
                    existingFirma.İl = firma.İl;
                    existingFirma.İlce = firma.İlce;
                    existingFirma.Adres = firma.Adres;

                    db.SaveChanges();

                    return RedirectToAction("ProfilDuzenle");
                }
            }

            return View("ProfilDuzenle", firma);
        }

        public ActionResult AnaSayfa()
		{
			var mail = (string)Session["mail"];
			var id = db.tblFirmalar.Where(x => x.mail == mail).Select(y => y.ID).FirstOrDefault();
			var toplamcagri=db.tblCagrilar.Where(x=>x.CagriFirma==id).Count();
			var aktifcagri = db.tblCagrilar.Where(x => x.CagriFirma == id && x.Durum==true).Count();
			var pasifcagri = db.tblCagrilar.Where(x => x.CagriFirma == id && x.Durum == false).Count();
			var yetkili=db.tblFirmalar.Where(x=>x.ID==id).Select(y=>y.Yetkili).FirstOrDefault();
			var sektor=db.tblFirmalar.Where(x=>x.ID == id).Select(y=>y.Sektor).FirstOrDefault();
			var firmaadi = db.tblFirmalar.Where(x => x.ID == id).Select(y => y.Ad).FirstOrDefault();
			var firmagorsel = db.tblFirmalar.Where(x => x.ID == id).Select(y => y.Gorsel).FirstOrDefault();
			ViewBag.c1=toplamcagri;
			ViewBag.c2=aktifcagri;
			ViewBag.c3=pasifcagri;
			ViewBag.c4=yetkili;
			ViewBag.c5=sektor;
			ViewBag.c6 =firmaadi;
			ViewBag.c7=firmagorsel;
			return View();
		}
		public PartialViewResult Partial1()
		{
			var mail = (string)Session["mail"];
			var id = db.tblFirmalar.Where(x => x.mail == mail).Select(y => y.ID).FirstOrDefault();
			var mesajlar =db.tblMesajlar.Where(x=>x.Alici==id && x.Durum == true).ToList();
			var mesajsayisi=db.tblMesajlar.Where(x=> x.Alici==id && x.Durum==true).Count();
			ViewBag.m1 = mesajsayisi;
			return PartialView(mesajlar);
		}
		public PartialViewResult Partial2()
		{
			var mail = (string)Session["mail"];
			var id = db.tblFirmalar.Where(x => x.mail == mail).Select(y => y.ID).FirstOrDefault();
			var cagrilar=db.tblCagrilar.Where(x=>x.CagriFirma==id && x.Durum == true).ToList();
			var cagrisayisi=db.tblCagrilar.Where(x=>x.CagriFirma==id && x.Durum==true).Count();
			ViewBag.m1 = cagrisayisi;
			return PartialView(cagrilar);
		}
		public ActionResult LogOut()
		{
			FormsAuthentication.SignOut();
			Session.Abandon();
			return RedirectToAction("Index","Login");
		}
		public PartialViewResult Partial3()
		{
			return PartialView();

		}

	}
}