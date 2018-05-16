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

		[HttpGet]
		[Route("api/clients")]
		public IQueryable<ClientDTO> GetBankAccount()
		{

			/*var acc = from a in db.BankAccounts

					  select new BankAccountDTO()
					  {
						  Id = a.BankAccountId,
						  OwnerId = a.BankAccountId,
						  OwnerName = a.AccountOwner.FirstName + " " + a.AccountOwner.LastName,
						  Balance = a.Balance
					  }

					  ;
			return acc;*/
			return db.Clients./*Include(b => b.Account).*/Select(AsClientDTO);

		}

		// GET: api/Clients/5
		[HttpGet]
		[Route("api/clients/{id}")]
		[ResponseType(typeof(ClientDTO))]
        public async Task<IHttpActionResult> GetClient(int id)
        {
			/* Client client = await db.Clients.FindAsync(id);
			 if (client == null)
			 {
				 return NotFound();
			 }

			 return Ok(client);*/
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