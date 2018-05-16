using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace PWApi.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }

	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

		public DbSet<BankAccount> BankAccounts { get; set; }
		public DbSet<Transaction> Transactions { get; set; }
		public DbSet<BankCustomer> BankCustomers { get; set; }

		public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<BankCustomer>()
				.HasOptional(x => x.Account)
				.WithRequired(c => c.AccountOwner)
				.Map(m => m.MapKey("Id"))
				.WillCascadeOnDelete(true);
		}
	}

	

	/*public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext()
			: base("DefaultConnection")
		{
		}

		public DbSet<BankAccount> BankAccounts { get; set; }
		public DbSet<Transaction> Transactions { get; set; }
		public DbSet<BankCustomer> BankCustomers { get; set; }

		public static ApplicationDbContext Create()
		{
			return new ApplicationDbContext();
		}
	}*/




}