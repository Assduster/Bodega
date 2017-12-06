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
            
            var news = db.news
                .OrderByDescending(x => x.Published).Include(x=> x.Image)
                .ToList();
            return Ok(news);
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
                    FileUpload imgupload = new FileUpload();
                    int length = httpPostedFile.ContentLength;
                    imgupload.imagedata = new byte[length]; //get imagedata  
                    httpPostedFile.InputStream.Read(imgupload.imagedata, 0, length);
                    imgupload.imagename = Path.GetFileName(httpPostedFile.FileName);
                    db.FileUploads.Add(imgupload);
                    db.SaveChanges();
                    var fileSavePath = Path.Combine(HttpContext.Current.Server.MapPath("~/Content/imgr"), httpPostedFile.FileName);
                    // Save the uploaded file to "UploadedFiles" folder  
                    httpPostedFile.SaveAs(fileSavePath);
                    return Ok("Image Uploaded");
                    
                }
            }
            return Ok("Image is not Uploaded");
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
            var img = db.news.FirstOrDefault(x => x.ImageId == x.ImageId);
            news.Published = DateTime.Now;
            news.Image.Id = img.Id;
            
            db.news.Add(news);
            db.SaveChanges();

            return Ok();
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