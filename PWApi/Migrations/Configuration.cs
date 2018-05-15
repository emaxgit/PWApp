namespace PWApi.Migrations
{
	using PWApi.Models;
	using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PWApi.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PWApi.Models.ApplicationDbContext context)
        {
			//  This method will be called after migrating to the latest version.

			//  You can use the DbSet<T>.AddOrUpdate() helper extension method 
			//  to avoid creating duplicate seed data.

		/*	context.BankCustomers.AddOrUpdate(x => x.Id,
			   new BankCustomer() { Id = 1, Name = "Jane Austen" },
			   new BankCustomer() { Id = 2, Name = "Charles Dickens" },
			   new BankCustomer() { Id = 3, Name = "Miguel de Cervantes" }
			   );

			context.BankAccounts.AddOrUpdate(x => x.Id,
				new BankAccount()
				{
					Id = 1,
					Title = "Pride and Prejudice",
					Year = 1813,
					AuthorId = 1,
					Price = 9.99M,
					Genre = "Commedy of manners"
				},
				new BankAccount()
				{
					Id = 2,
					Title = "Northanger Abbey",
					Year = 1817,
					AuthorId = 1,
					Price = 12.95M,
					Genre = "Gothic parody"
				},
				new BankAccount()
				{
					Id = 3,
					Title = "David Copperfield",
					Year = 1850,
					AuthorId = 2,
					Price = 15,
					Genre = "Bildungsroman"
				},
				new BankAccount()
				{
					Id = 4,
					Title = "Don Quixote",
					Year = 1617,
					AuthorId = 3,
					Price = 8.95M,
					Genre = "Picaresque"
				});*/
		}
    }
}
