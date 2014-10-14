using FinalProV2.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProV2.Web.Models
{
	public class ContentCategoryVM
	{
		public Content Content { get; set; }
		public List<Category> Category { get; set; }
	}
}