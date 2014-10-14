using FinalProV2.DataModels;
using FinalProV2.Db;
using FinalProV2.Db.Adapters.Data;
using FinalProV2.Db.Adapters.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProV2.Web.Controllers
{
	public class HomeController : Controller
	{
		IFinalProV2Adapter _adapter;
		public HomeController() {
			_adapter = new FinalProV2Adapter();
		}
		public HomeController(IFinalProV2Adapter adapter) {
			_adapter = adapter;
		}
		public ActionResult Index()
		{
			List<Category> categorys = _adapter.GetAllCategory();
			return View(categorys);
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}