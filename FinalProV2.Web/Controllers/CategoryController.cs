using FinalProV2.Db;
using FinalProV2.Db.Adapters.Data;
using FinalProV2.Db.Adapters.Interfaces;
using FinalProV2.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProV2.Web.Controllers
{
    public class CategoryController : Controller
    {
		IFinalProV2Adapter _adapter;
		public CategoryController()
		{
			_adapter = new FinalProV2Adapter();
		}
		public CategoryController(IFinalProV2Adapter adapter)
		{
			_adapter = adapter;
		}
		/*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
		public ActionResult CategoryDetail(int id)
		{
			ContentVM vm = new ContentVM();
			vm.Category = _adapter.GetCategory(id);
			return View(vm);
		}
		[HttpGet]
		public ActionResult EditCategory(int id)
		{
			Category category = _adapter.GetCategory(id);
			return View(category);
		}
		/*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
		[HttpPost]
		public ActionResult Edit(Category category)
		{
			category = _adapter.UpdateCategory(category);
			return RedirectToAction("Index");
		}
		//[HttpPost]
		//public ActionResult Delete(int id)
		//{
		//	Category category = _adapter.DeleteCategory(id);
		//	return Redirect("Index");
		//}
    }
}