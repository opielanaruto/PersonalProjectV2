using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProV2.DataModels
{
	public class Content
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Link { get; set; }
		public string Image { get; set; }
		public int CategoryId { get; set; }

		public void SetProps(Content content)
		{
			this.Title = content.Title;
			this.Link = content.Link;
			this.Image = content.Image;
			this.CategoryId = content.CategoryId;
		}
	}
}
