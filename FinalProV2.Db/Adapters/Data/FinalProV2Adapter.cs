using FinalProV2.DataModels;
using FinalProV2.Db.Adapters.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProV2.Db.Adapters.Data
{
	public class FinalProV2Adapter :IFinalProV2Adapter
	{
		/*~Category~*/
		public Category AddCategory(Category category)
		{
			using (ApplicationDbContext db = new ApplicationDbContext())
			{
				category = db.Categorys.Add(category);
				db.SaveChanges();
			}
			return category;
		}
		public List<Category> GetAllCategory()
		{
			List<Category> categorys;
			using (ApplicationDbContext db = new ApplicationDbContext())
			{
				categorys = db.Categorys.Include("Contents").OrderBy(x => x.Title).ToList();
			}
			return categorys;
		}
		public Category GetCategory(int id)
		{
			Category category;
			using (ApplicationDbContext db = new ApplicationDbContext())
			{
				category = db.Categorys.Include("Contents").Where(x => x.Id == id).FirstOrDefault();
			}
			return category;
		}
		public Category UpdateCategory(Category category)
		{
			using (ApplicationDbContext db = new ApplicationDbContext())
			{
				Category updatingCategory = db.Categorys.Find(category.Id);
				updatingCategory.SetProps(category);
				db.SaveChanges();
			}
			return category;
		}
		public void DeleteCategory(int id)
		{
			using (ApplicationDbContext db = new ApplicationDbContext())
			{
				Category category = db.Categorys.Find(id);
				db.Categorys.Remove(category);
				db.SaveChanges();
			}
		}
		/*~Content~*/
		public Content AddContent(Content content)
		{
			using (ApplicationDbContext db = new ApplicationDbContext())
			{
				content = db.Contents.Add(content);
				db.SaveChanges();
			}
			return content;
		}
		public List<Content> GetAllContent()
		{
			List<Content> contents;
			using (ApplicationDbContext db = new ApplicationDbContext())
			{
				contents = db.Contents.OrderBy(x => x.Title).ToList();
			}
			return contents;
		}
		public Content GetContent(int id)
		{
			Content contents;
			using (ApplicationDbContext db = new ApplicationDbContext())
			{
				contents = db.Contents.Where(x => x.Id == id).FirstOrDefault();
			}
			return contents;
		}
		public Content UpdateContent(Content content)
		{
			using (ApplicationDbContext db = new ApplicationDbContext())
			{
				Content updatingContent = db.Contents.Find(content.Id);
				updatingContent.SetProps(content);
				db.SaveChanges();
			}
			return content;
		}
		public void DeleteContent(int id)
		{
			using (ApplicationDbContext db = new ApplicationDbContext())
			{
				Content content = db.Contents.Find(id);
				db.Contents.Remove(content);
				db.SaveChanges();
			}
		}
	}
}
