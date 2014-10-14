using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalProV2.DataModels;
using FinalProV2.Db;
using FinalProV2.Web;
using FinalProV2.Db.Adapters;
using FinalProV2.Db.Migrations;
using FinalProV2.Db.Adapters.Interfaces;
using FinalProV2.Db.Adapters.Data;

namespace FinalProV2.Web.Controllers
{
	public class ContentController : Controller
	{
		/*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
		IFinalProV2Adapter _adapter;
		public ContentController()
		{
			_adapter = new FinalProV2Adapter();
		}
		public ContentController(IFinalProV2Adapter adapter)
		{
			_adapter = adapter;
		}
		/*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
		[HttpGet]
		public ActionResult AddContent(int id)
		{
			return View(id);
		}
		[HttpPost]
		public ActionResult AddContent(string title, int categoryId)
		{
			Content c = new Content();
			c.Title = title;
			c.CategoryId = categoryId;
			c = _adapter.AddContent(c);
			return RedirectToAction("Home/Index");
		}
		/*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
		[HttpPost]
		public ActionResult Edit(Content content)
		{
			content = _adapter.UpdateContent(content);
			return RedirectToAction("Home/Index");
		}
		[HttpPost]
		public ActionResult Delete(int id)
		{
			_adapter.DeleteContent(id);
			return Redirect("/Home/Index");
		}
		/*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
	}
}