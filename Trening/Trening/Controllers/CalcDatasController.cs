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
using Trening.Utilities;

namespace Trening.Controllers
{
    [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
    public class CalcDatasController : ApiController
    {
        
        private TreningEntities db = new TreningEntities();

        // GET: api/CalcDatas
        public IQueryable<CalcData> GetCalcData()
        {
            return db.CalcData;
        }

        // GET: api/CalcDatas/5
        [ResponseType(typeof(CalcData))]
        public IHttpActionResult GetCalcData(int id)
        {
            CalcData calcData = db.CalcData.Find(id);
            if (calcData == null)
            {
                return NotFound();
            }

            return Ok(calcData);
        }

        // PUT: api/CalcDatas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCalcData(int id, CalcData calcData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != calcData.ID)
            {
                return BadRequest();
            }

            db.Entry(calcData).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CalcDataExists(id))
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

        // POST: api/CalcDatas
        [ResponseType(typeof(CalcData))]
        public IHttpActionResult PostCalcData(CalcData calcData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var macroCalculator = new MacroCalculator(calcData);
            calcData.KcalResult = macroCalculator.calculateMacros();
            db.CalcData.Add(calcData);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = calcData.ID }, calcData);
        }

        // DELETE: api/CalcDatas/5
        [ResponseType(typeof(CalcData))]
        public IHttpActionResult DeleteCalcData(int id)
        {
            CalcData calcData = db.CalcData.Find(id);
            if (calcData == null)
            {
                return NotFound();
            }

            db.CalcData.Remove(calcData);
            db.SaveChanges();

            return Ok(calcData);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CalcDataExists(int id)
        {
            return db.CalcData.Count(e => e.ID == id) > 0;
        }
    }
}