using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using PWApi.Models;

namespace PWApi.Controllers
{
    public class BankAccountsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

		/* // GET: api/BankAccounts
		 public IQueryable<BankAccount> GetBankAccounts()
		 {
			 return db.BankAccounts.Where(a => a.BankCustomerId == userId).Include(a => a.Transactions);
		 }*/

		// GET: api/Accounts
		[HttpGet]
		[Route("api/ba")]
		public IQueryable<BankAccountDTO> GetBankAccount ()
		{
		
		     var acc = from a in db.BankAccounts
					 
					  select new BankAccountDTO()
					  {
						  Id = a.BankAccountId,
						  OwnerId = a.BankAccountId,
						  OwnerName = a.AccountOwner.FirstName + " " + a.AccountOwner.LastName,
						  Balance = a.Balance
					  }

					   ;
			return acc;

		}


		// GET: api/BankAccounts/5
		[HttpGet]
		[Route("api/ba/owner/{ownerId}")]
		[ResponseType(typeof(BankAccountDTO))]
        public async Task<IHttpActionResult> GetBankAccount(int ownerId)
        {
			BankAccountDTO bankAccount = await db.BankAccounts.Select(a =>
			new BankAccountDTO()
			{
				Id = a.BankAccountId,
				OwnerId = a.BankAccountId,
				OwnerName = a.AccountOwner.FirstName + " " + a.AccountOwner.LastName,
				Balance = a.Balance

			}).SingleOrDefaultAsync(a => a.OwnerId== ownerId);


				
			if (bankAccount == null)
            {
                return NotFound();
            }

            return Ok(bankAccount);
        }

        // PUT: api/BankAccounts/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBankAccount(int id, BankAccount bankAccount)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bankAccount.BankAccountId)
            {
                return BadRequest();
            }

            db.Entry(bankAccount).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BankAccountExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/BankAccounts
        [ResponseType(typeof(BankAccount))]
        public async Task<IHttpActionResult> PostBankAccount(BankAccount bankAccount)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BankAccounts.Add(bankAccount);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = bankAccount.BankAccountId }, bankAccount);
        }

        // DELETE: api/BankAccounts/5
        [ResponseType(typeof(BankAccount))]
        public async Task<IHttpActionResult> DeleteBankAccount(int id)
        {
            BankAccount bankAccount = await db.BankAccounts.FindAsync(id);
            if (bankAccount == null)
            {
                return NotFound();
            }

            db.BankAccounts.Remove(bankAccount);
            await db.SaveChangesAsync();

            return Ok(bankAccount);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BankAccountExists(int id)
        {
            return db.BankAccounts.Count(e => e.BankAccountId == id) > 0;
        }
    }
}