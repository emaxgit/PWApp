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
    public class BankCustomersController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/BankCustomers
        public IQueryable<BankCustomer> GetBankCustomers()
        {
            return db.BankCustomers;
        }

        // GET: api/BankCustomers/5
        [ResponseType(typeof(BankCustomer))]
        public async Task<IHttpActionResult> GetBankCustomer(int id)
        {
            BankCustomer bankCustomer = await db.BankCustomers.FindAsync(id);
            if (bankCustomer == null)
            {
                return NotFound();
            }

            return Ok(bankCustomer);
        }

        // PUT: api/BankCustomers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBankCustomer(int id, BankCustomer bankCustomer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bankCustomer.Id)
            {
                return BadRequest();
            }

            db.Entry(bankCustomer).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BankCustomerExists(id))
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

        // POST: api/BankCustomers
        [ResponseType(typeof(BankCustomer))]
        public async Task<IHttpActionResult> PostBankCustomer(BankCustomer bankCustomer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BankCustomers.Add(bankCustomer);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = bankCustomer.Id }, bankCustomer);
        }

        // DELETE: api/BankCustomers/5
        [ResponseType(typeof(BankCustomer))]
        public async Task<IHttpActionResult> DeleteBankCustomer(int id)
        {
            BankCustomer bankCustomer = await db.BankCustomers.FindAsync(id);
            if (bankCustomer == null)
            {
                return NotFound();
            }

            db.BankCustomers.Remove(bankCustomer);
            await db.SaveChangesAsync();

            return Ok(bankCustomer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BankCustomerExists(int id)
        {
            return db.BankCustomers.Count(e => e.Id == id) > 0;
        }
    }
}