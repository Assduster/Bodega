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
using System.Web;
using System.IO;

namespace Bodega.dev.api
{
    public class NewsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/News
        public IHttpActionResult Getnews()
        {
            var imageses = db.News
                .OrderByDescending(x => x.Published)
                .Include(x => x.ImageUploads).Take(10)
                .ToList();
            return Ok(imageses);
        }

        [HttpPost]
        [Route("api/fileUpload")]
        public IHttpActionResult PostFileUpload()
        {
           
            if (HttpContext.Current.Request.Files.AllKeys.Any())
            {
                // Get the uploaded image from the Files collection  
                var httpPostedFile = HttpContext.Current.Request.Files["UploadedImage"];
                if (httpPostedFile != null)
                {
                    ImageUpload imgupload = new ImageUpload();
                    int length = httpPostedFile.ContentLength;
                    imgupload.ImageUrl = Path.GetFileName(httpPostedFile.FileName);
                    db.ImageUploads.Add(imgupload);
                    db.SaveChanges();
                    var fileSavePath = Path.Combine(HttpContext.Current.Server.MapPath("~/Content/imgr"), httpPostedFile.FileName);
                    // Save the uploaded file to "UploadedFiles" folder  
                    httpPostedFile.SaveAs(fileSavePath);
                    //return CreatedAtRoute("DefaultApi", new { id = imageUpload.Id }, imageUpload);

                }
            }
            return Ok("Image is not Uploaded");
        }

        // GET: api/News/5
        [ResponseType(typeof(News))]
        public IHttpActionResult GetNews(int id)
        {
            News news = db.News.Find(id);
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

            var img = db.ImageUploads.OrderByDescending(x => x.Id).First();
            news.ImageUploads = img;
            if(news.ImageUploads == null)
            {
                return BadRequest();
            }

            news.Published = DateTime.Now;
            db.News.Add(news);
            db.Entry(news.ImageUploads).State = EntityState.Unchanged;
            db.SaveChanges();

            return Ok();
        }

        // DELETE: api/News/5
        [ResponseType(typeof(News))]
        public IHttpActionResult DeleteNews(int id)
        {
            News news = db.News.Find(id);
            if (news == null)
            {
                return NotFound();
            }

            db.News.Remove(news);
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
            return db.News.Count(e => e.Id == id) > 0;
        }
    }
}