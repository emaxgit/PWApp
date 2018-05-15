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
			context.BankCustomers.AddOrUpdate(x => x.Id,
				  new BankCustomer() { Id = 1, Email = "elena@mail.ru" , Password ="123", FirstName="elena", LastName="maximova"},
				  new BankCustomer() { Id = 2, Email = "charles@gmail.com", Password = "123", FirstName = "charles", LastName = "dickens" },
				  new BankCustomer() { Id = 3, Email = "bruce@gmail.com", Password = "123", FirstName = "bruce", LastName = "willis" }
				  );

			context.BankAccounts.AddOrUpdate(x => x.Id,
				new BankAccount()
				{
					Id = 1,
					Number = "12345678",
					Balance = 550,
					OpenDate = DateTime.Now,
					BankCustomerId = 1
				},
				new BankAccount()
				{
					Id = 1,
					Number = "87654321",
					Balance = 550,
					OpenDate = DateTime.Now,
					BankCustomerId = 2
				},
				new BankAccount()
				{
					Id = 1,
					Number = "81726354",
					Balance = 550,
					OpenDate = DateTime.Now,
					BankCustomerId = 3
				});
		}
    }
}
