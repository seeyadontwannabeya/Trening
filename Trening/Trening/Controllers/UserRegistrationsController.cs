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
using Trening.Models;
using Trening.Library;

namespace Trening.Controllers
{
    [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
    public class UserRegistrationsController : ApiController
    {
        private TreningEntities db = new TreningEntities();
        private LoginUtility loginUtil = new LoginUtility();
        [Route("login")]
        [HttpPost]
        public AccessTokenViewModel Login(UserLoginModel userLogin)
        {
            var tokenString = loginUtil.Login(userLogin.username, userLogin.password);
            if (tokenString != string.Empty)
            {
                var expireDate = DateTime.Now.AddHours(1);
                db.accesstokens.Add(new accesstokens { token = tokenString, expires = expireDate, created = DateTime.Now });
                db.SaveChanges();

                return new AccessTokenViewModel { accessToken = tokenString, expireDate = expireDate, };
            }
            else
            {
                return null;
            }
        }
        // GET: api/UserRegistrations
        public IQueryable<UserRegistration> GetUserRegistration()
        {
            return db.UserRegistration;
        }

        // GET: api/UserRegistrations/5
        [ResponseType(typeof(UserRegistration))]
        public IHttpActionResult GetUserRegistration(int id)
        {
            UserRegistration userRegistration = db.UserRegistration.Find(id);
            if (userRegistration == null)
            {
                return NotFound();
            }

            return Ok(userRegistration);
        }

        // PUT: api/UserRegistrations/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUserRegistration(int id, UserRegistration userRegistration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userRegistration.ID)
            {
                return BadRequest();
            }

            db.Entry(userRegistration).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserRegistrationExists(id))
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

        // POST: api/UserRegistrations
        [ResponseType(typeof(UserRegistration))]
        public IHttpActionResult PostUserRegistration(UserRegistration userRegistration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UserRegistration.Add(userRegistration);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = userRegistration.ID }, userRegistration);
        }

        // DELETE: api/UserRegistrations/5
        [ResponseType(typeof(UserRegistration))]
        public IHttpActionResult DeleteUserRegistration(int id)
        {
            UserRegistration userRegistration = db.UserRegistration.Find(id);
            if (userRegistration == null)
            {
                return NotFound();
            }

            db.UserRegistration.Remove(userRegistration);
            db.SaveChanges();

            return Ok(userRegistration);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserRegistrationExists(int id)
        {
            return db.UserRegistration.Count(e => e.ID == id) > 0;
        }
    }
}