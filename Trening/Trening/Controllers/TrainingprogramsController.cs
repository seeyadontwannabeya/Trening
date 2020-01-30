using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using Trening.Library.Utilities;
using Trening.Models;

namespace Trening.Controllers
{
    [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
    public class TrainingprogramsController : ApiController
    {
        private TreningEntities db = new TreningEntities();

        // GET: api/Trainingprograms
        public IQueryable<Trainingprogram> GetTrainingprogram()
        {
            return db.Trainingprogram;
        }

        // GET: api/Trainingprograms/5
        [ResponseType(typeof(Trainingprogram))]
        public IHttpActionResult GetTrainingprogram(int id)
        {
            Trainingprogram trainingprogram = db.Trainingprogram.Find(id);
            if (trainingprogram == null)
            {
                return NotFound();
            }

            return Ok(trainingprogram);
        }

        // PUT: api/Trainingprograms/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTrainingprogram(int id, Trainingprogram trainingprogram)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != trainingprogram.ID)
            {
                return BadRequest();
            }

            db.Entry(trainingprogram).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrainingprogramExists(id))
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

        // POST: api/Trainingprograms
        [ResponseType(typeof(Trainingprogram))]
        public IHttpActionResult PostTrainingprogram(Trainingprogram trainingprogram)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ts = new TrainingSchema(trainingprogram);
            trainingprogram.Trainingprogram1 = ts.GenerateSchema();
            trainingprogram.RegID = 1;
            db.Trainingprogram.Add(trainingprogram);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = trainingprogram.ID }, trainingprogram);
        }

        // DELETE: api/Trainingprograms/5
        [ResponseType(typeof(Trainingprogram))]
        public IHttpActionResult DeleteTrainingprogram(int id)
        {
            Trainingprogram trainingprogram = db.Trainingprogram.Find(id);
            if (trainingprogram == null)
            {
                return NotFound();
            }

            db.Trainingprogram.Remove(trainingprogram);
            db.SaveChanges();

            return Ok(trainingprogram);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TrainingprogramExists(int id)
        {
            return db.Trainingprogram.Count(e => e.ID == id) > 0;
        }
    }
}