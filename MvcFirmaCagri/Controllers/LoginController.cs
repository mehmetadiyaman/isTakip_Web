using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcFirmaCagri.Models.Entitiy;

namespace MvcFirmaCagri.Controllers
{
	public class LoginController : Controller
	{
		// GET: Login
		DbisTAKİPEntities db = new DbisTAKİPEntities();
		public ActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public ActionResult Index(tblFirmalar p)
		{
			var bilgiler = db.tblFirmalar.FirstOrDefault(x => x.mail == p.mail && x.Sifre == p.Sifre);
			if (bilgiler != null)
			{
				FormsAuthentication.SetAuthCookie(bilgiler.mail, false);
				Session["mail"] = bilgiler.mail.ToString();
				return RedirectToAction("AktifCagrilar", "Default");
			}
			else
			{
				return RedirectToAction("Index");
			}
		}
	}
}