using FinalProV2.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProV2.Web.Models
{
	public class ContentVM
	{
		public Content Content { get; set; }
		public Category Category { get; set; }
	}
}