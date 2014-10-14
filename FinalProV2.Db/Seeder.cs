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
		public static void Seed(ApplicationDbContext db,
			bool seedCategorys = true,
			bool seedContent = true)
		{
			if (seedCategorys)
			{
				db.Categorys.AddOrUpdate(
					x => x.Title,
					new Category { Title = "Docs" },
					new Category { Title = "Tutorials" });
				db.SaveChanges();
			}
			if (seedContent)
			{
				db.Contents.AddOrUpdate(
					x => x.Title,
					/*The Docs*/
				new Content { Title = "MDN", Link = "https://developer.mozilla.org/en-US/", Image = "https://mdn.mozillademos.org/files/6457/mdn_logo_only_color.png", CategoryId = 1 },
				new Content { Title = "MSDN", Link = "http://msdn.microsoft.com/en-us/default.aspx", Image = "http://www.winbeta.org/sites/default/files/newsimages/msdn_lg%5B11%5D.jpg", CategoryId = 1 },
				new Content { Title = "W3Schools", Link = "http://www.w3schools.com/", Image = "http://1.bp.blogspot.com/-8PoxUOsFWVk/UYam-krJm7I/AAAAAAAAABM/Yga2gCSs3QE/s1600/9147a7d684457bc108c8f2393aa41662.png", CategoryId = 1 },
				new Content { Title = "Css-Tricks", Link = "http://css-tricks.com/", Image = "http://seizedesigns.com/wp-content/uploads/2014/07/css-tricks.png", CategoryId = 1 },
				new Content { Title = "AngularJS", Link = "https://angularjs.org/", Image = "http://3.bp.blogspot.com/-p7FmgCOsIxE/U3RbmRukK4I/AAAAAAAAAFw/6hcwWM_U-ts/s1600/Angular.png", CategoryId = 1 },
					/*Tutorials*/
				new Content { Title = "Code School", Link = "https://www.codeschool.com/?utm_source=google&utm_medium=cpc&utm_content=home_page&utm_campaign=branded&gclid=CjwKEAjwzeihBRCQ84bhxrz_0w8SJAAohyh1EIzbdVnI_-yT040AyzptcFtoo51_3YX0HKUPg-pT5xoCjz_w_wcB", Image = "http://www.desiiign.net/wp-content/uploads/2013/10/CodeSchool.png", CategoryId = 2 },
				new Content { Title = "Khan Academy", Link = "https://www.khanacademy.org/", Image = "http://cdn.shopify.com/s/files/1/0149/4466/products/IMG_20120509_104230_1024x1024.jpg?v=1336585643", CategoryId = 2 },
				new Content { Title = "HTML Dog", Link = "http://www.htmldog.com/", Image = "http://meijun.cc/blog/wp-content/uploads/2013/01/logofolio-html_dog-1.png", CategoryId = 2 });
			}
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
