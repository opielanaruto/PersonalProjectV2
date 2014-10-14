using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProV2.Db
{
	public class Category
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public virtual List<Content> contents { get; set; }

		public void SetProps(Category category)
		{
			this.Title = category.Title;
		}
	}
}
