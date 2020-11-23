using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using EDMApi.Models;

namespace EDMApi.Controllers
{
    public class testTablesController : ApiController
    {
        private NorthwindEntities db = new NorthwindEntities();

        // GET: api/testTables
        public IQueryable<testTable> GettestTable()
        {
            return db.testTable;
        }

        // GET: api/testTables/5
        [ResponseType(typeof(testTable))]
        public IHttpActionResult GettestTable(int id)
        {
            testTable testTable = db.testTable.Find(id);
            if (testTable == null)
            {
                return NotFound();
            }

            return Ok(testTable);
        }

        // PUT: api/testTables/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttestTable(int id, testTable testTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != testTable.id)
            {
                return BadRequest();
            }

            db.Entry(testTable).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!testTableExists(id))
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

        // POST: api/testTables
        [ResponseType(typeof(testTable))]
        public IHttpActionResult PosttestTable(testTable testTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.testTable.Add(testTable);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = testTable.id }, testTable);
        }

        // DELETE: api/testTables/5
        [ResponseType(typeof(testTable))]
        public IHttpActionResult DeletetestTable(int id)
        {
            testTable testTable = db.testTable.Find(id);
            if (testTable == null)
            {
                return NotFound();
            }

            db.testTable.Remove(testTable);
            db.SaveChanges();

            return Ok(testTable);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool testTableExists(int id)
        {
            return db.testTable.Count(e => e.id == id) > 0;
        }
    }
}