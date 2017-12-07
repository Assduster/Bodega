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
using Bodega.dev.Models;
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
using System.Web;
using System.IO;
>>>>>>> parent of 27c373d... ww
=======
>>>>>>> parent of 3da7a65... work
=======
>>>>>>> parent of ddb9a3e... GG

namespace Bodega.dev.api
{
    public class NewsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/News
        public IHttpActionResult Getnews()
        {
<<<<<<< HEAD
<<<<<<< HEAD

            var news = db.news
=======
            
            var news = db.news
                .OrderByDescending(x => x.Published).Include(x=> x.Image)
>>>>>>> parent of 27c373d... ww
=======

            var news = db.news
>>>>>>> parent of ddb9a3e... GG
                .ToList();
            return Ok(news);
        }

        // GET: api/News/5
        [ResponseType(typeof(News))]
        public IHttpActionResult GetNews(int id)
        {
            News news = db.news.Find(id);
            if (news == null)
            {
                return NotFound();
            }

            return Ok(news);
        }

        // PUT: api/News/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNews(int id, News news)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != news.Id)
            {
                return BadRequest();
            }

            db.Entry(news).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NewsExists(id))
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

        // POST: api/News
        [ResponseType(typeof(News))]
        public IHttpActionResult PostNews(News news)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            news.Published = DateTime.Now;
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD

=======
            news.Image.Id = img.Id;
            
>>>>>>> parent of 27c373d... ww
=======

>>>>>>> parent of 3da7a65... work
=======

>>>>>>> parent of ddb9a3e... GG
            db.news.Add(news);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = news.Id }, news);
        }

        // DELETE: api/News/5
        [ResponseType(typeof(News))]
        public IHttpActionResult DeleteNews(int id)
        {
            News news = db.news.Find(id);
            if (news == null)
            {
                return NotFound();
            }

            db.news.Remove(news);
            db.SaveChanges();

            return Ok(news);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NewsExists(int id)
        {
            return db.news.Count(e => e.Id == id) > 0;
        }
    }
}