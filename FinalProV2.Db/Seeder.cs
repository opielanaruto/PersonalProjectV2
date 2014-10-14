using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.Migrations;
using FinalProV2.DataModels;

namespace FinalProV2.Db
{
	public static class Seeder
	{
		public static void Seed(ApplicationDbContext db)
		{
			///*~Seed Categorys~*/
			//db.Categorys.AddOrUpdate(
			//	x => x.Title,
			//	new Category("Docs"),
			//	new Category("Tutorials")
			//);
			//db.SaveChanges();
			///*~Seed Content~*/
			//db.Contents.AddOrUpdate(
			//	x => x.Title,
			//	/*The Docs*/
			//	new Content("MDN", "https://developer.mozilla.org/en-US/", "https://mdn.mozillademos.org/files/6457/mdn_logo_only_color.png", 1),
			//	new Content("MSDN", "http://msdn.microsoft.com/en-us/default.aspx", "http://www.winbeta.org/sites/default/files/newsimages/msdn_lg%5B11%5D.jpg", 1),
			//	new Content("W3Schools", "http://www.w3schools.com/", "http://1.bp.blogspot.com/-8PoxUOsFWVk/UYam-krJm7I/AAAAAAAAABM/Yga2gCSs3QE/s1600/9147a7d684457bc108c8f2393aa41662.png", 1),
			//	new Content("Css-Tricks", "http://css-tricks.com/", "http://seizedesigns.com/wp-content/uploads/2014/07/css-tricks.png", 1),
			//	new Content("AngularJS", "https://angularjs.org/", "http://3.bp.blogspot.com/-p7FmgCOsIxE/U3RbmRukK4I/AAAAAAAAAFw/6hcwWM_U-ts/s1600/Angular.png", 1),
			//	/*Tutorials*/
			//	new Content("Code School", "https://www.codeschool.com/?utm_source=google&utm_medium=cpc&utm_content=home_page&utm_campaign=branded&gclid=CjwKEAjwzeihBRCQ84bhxrz_0w8SJAAohyh1EIzbdVnI_-yT040AyzptcFtoo51_3YX0HKUPg-pT5xoCjz_w_wcB", "http://www.desiiign.net/wp-content/uploads/2013/10/CodeSchool.png", 2),
			//	new Content("Khan Academy", "https://www.khanacademy.org/", "http://cdn.shopify.com/s/files/1/0149/4466/products/IMG_20120509_104230_1024x1024.jpg?v=1336585643", 2),
			//	new Content("HTML Dog", "http://www.htmldog.com/", "http://meijun.cc/blog/wp-content/uploads/2013/01/logofolio-html_dog-1.png", 2)
			//	);
			db.SaveChanges();
			/*~Seed Users~*/
			var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
			roleManager.Create(new IdentityRole { Name = "Admin" });
			db.SaveChanges();

			List<ApplicationUser> users = new List<ApplicationUser>() 
            {
                new ApplicationUser() {UserName="Admin", Email="email@email.com"},
                new ApplicationUser() {UserName="JohnDoe", Email="JohnDoe@email.com"},
                new ApplicationUser() {UserName="JaneDoe", Email="JaneDoe@email.com"}
            };
			using (var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db)))
			{
				userManager.Create(users[0], "123456aA!");
				users[0] = userManager.FindByName(users[0].UserName);
				userManager.Create(users[1], "John123!");
				userManager.Create(users[2], "Jane123!");
				db.SaveChanges();
				userManager.AddToRole(users[0].Id, "Admin");
			}
			db.SaveChanges();
		}
	}
}
