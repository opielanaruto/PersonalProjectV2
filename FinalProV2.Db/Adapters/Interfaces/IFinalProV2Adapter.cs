using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProV2.Db.Adapters.Interfaces
{
	public interface IFinalProV2Adapter
	{/*CRUD*/

		/*Category*/
		Category AddCategory(Category category);
		List<Category> GetAllCategory();
		Category GetCategory(int id);
		Category UpdateCategory(Category category);
		void DeleteCategory(int id);
		/*Content*/
		Content AddContent(Content content);
		List<Content> GetAllContent();
		Content GetContent(int id);
		Content UpdateContent(Content content);
		void DeleteContent(int id);
	}
}
