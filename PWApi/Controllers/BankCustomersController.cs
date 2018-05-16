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
    public class ClientsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Clients
        public IQueryable<Client> GetClients()
        {
			
			return db.Clients;
        }

        // GET: api/Clients/5
        [ResponseType(typeof(Client))]
        public async Task<IHttpActionResult> GetClient(int id)
        {
            Client Client = await db.Clients.FindAsync(id);
            if (Client == null)
            {
                return NotFound();
            }

            return Ok(Client);
        }

        // PUT: api/Clients/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutClient(int id, Client Client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != Client.Id)
            {
                return BadRequest();
            }

            db.Entry(Client).State = EntityState.Modified;

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
        public async Task<IHttpActionResult> PostClient(Client Client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Clients.Add(Client);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = Client.Id }, Client);
        }

        // DELETE: api/Clients/5
        [ResponseType(typeof(Client))]
        public async Task<IHttpActionResult> DeleteClient(int id)
        {
            Client Client = await db.Clients.FindAsync(id);
            if (Client == null)
            {
                return NotFound();
            }

            db.Clients.Remove(Client);
            await db.SaveChangesAsync();

            return Ok(Client);
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