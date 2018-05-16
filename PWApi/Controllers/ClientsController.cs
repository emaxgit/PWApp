using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using PWApi.Models;

namespace PWApi.Controllers
{
	[RoutePrefix("api/clients")]
	public class ClientsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

		/*// GET: api/Clients
        public IQueryable<Client> GetClients()
        {
            return db.Clients;
        }*/

		// Typed lambda expression for Select() method. 
		private static readonly Expression<Func<Client, ClientDTO>> AsClientDTO =
			x => new ClientDTO
			{
				/*Title = x.Title,
				Author = x.Author.Name,
				Genre = x.Genre*/
				Id = x.Id,
				ClientName = x.FirstName + " " + x.LastName,
				ClientBalance = x.Account.Balance
				
			};

		private static readonly Expression<Func<BankAccount, BankAccountDTO>> AsBankAccountDTO =
			a => new BankAccountDTO
			{
				
				Id = a.BankAccountId,
				OwnerId= a.AccountOwner.Id,
				Balance=a.Balance,
				Number = a.Number,
				OpenDate= a.OpenDate
			};

		[HttpGet]
		[Route("")]
		public IQueryable<ClientDTO> GetBankAccount()
		{

			return db.Clients./*Include(b => b.Account).*/Select(AsClientDTO);

		}

		// GET: api/Clients/5
		[HttpGet]
		[Route("{id:int}")]
		[ResponseType(typeof(ClientDTO))]
        public async Task<IHttpActionResult> GetClient(int id)
        {
			
			ClientDTO client = await db.Clients/*.Include(b => b.Account)*/
				.Where(b => b.Id == id)
				.Select(AsClientDTO)
				.FirstOrDefaultAsync();
			if (client == null)
			{
				return NotFound();
			}

			return Ok(client);
		}

		// GET: api/Clients/5/Accounts
		[HttpGet]
		[Route("{id}/accounts")]
		[ResponseType(typeof(BankAccountDTO))]
		public async Task<IHttpActionResult> GetClientAccount(int id)
		{

			BankAccountDTO account = await db.BankAccounts
				.Where(a => a.AccountOwner.Id == id)
				.Select(AsBankAccountDTO)
				.FirstOrDefaultAsync();
			if (account == null)
			{
				return NotFound();
			}

			return Ok(account);
		}

		// GET: api/Clients/5/Transactions
		[HttpGet]
		[Route("{id}/tran")]
		[ResponseType(typeof(BankAccountDTO))]
		public async Task<IHttpActionResult> GetClientTransactions(int id)
		{

			BankAccountDTO account = await db.BankAccounts
				.Where(a => a.AccountOwner.Id == id)
				.Select(AsBankAccountDTO)
				.FirstOrDefaultAsync();
			if (account == null)
			{
				return NotFound();
			}

			return Ok(account);
		}

		// PUT: api/Clients/5
		[ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutClient(int id, Client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != client.Id)
            {
                return BadRequest();
            }

            db.Entry(client).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientExists(id))
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

        // POST: api/Clients
        [ResponseType(typeof(Client))]
        public async Task<IHttpActionResult> PostClient(Client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Clients.Add(client);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = client.Id }, client);
        }

        // DELETE: api/Clients/5
        [ResponseType(typeof(Client))]
        public async Task<IHttpActionResult> DeleteClient(int id)
        {
            Client client = await db.Clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            db.Clients.Remove(client);
            await db.SaveChangesAsync();

            return Ok(client);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClientExists(int id)
        {
            return db.Clients.Count(e => e.Id == id) > 0;
        }
    }
}