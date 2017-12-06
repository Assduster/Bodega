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

namespace Bodega.dev.api
{
    public class FileUploadsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/FileUploads
        public IHttpActionResult GetFileUploads()
        {
            var latestfiles = db.FileUploads.Take(1);
            return Ok(latestfiles);
        }

        // GET: api/FileUploads/5
        [ResponseType(typeof(FileUpload))]
        public IHttpActionResult GetFileUpload(int id)
        {
            FileUpload fileUpload = db.FileUploads.Find(id);
            if (fileUpload == null)
            {
                return NotFound();
            }

            return Ok(fileUpload);
        }

        // PUT: api/FileUploads/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFileUpload(int id, FileUpload fileUpload)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != fileUpload.Id)
            {
                return BadRequest();
            }

            db.Entry(fileUpload).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FileUploadExists(id))
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

        // POST: api/FileUploads
        [ResponseType(typeof(FileUpload))]
        public IHttpActionResult PostFileUpload(FileUpload fileUpload)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.FileUploads.Add(fileUpload);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = fileUpload.Id }, fileUpload);
        }

        // DELETE: api/FileUploads/5
        [ResponseType(typeof(FileUpload))]
        public IHttpActionResult DeleteFileUpload(int id)
        {
            FileUpload fileUpload = db.FileUploads.Find(id);
            if (fileUpload == null)
            {
                return NotFound();
            }

            db.FileUploads.Remove(fileUpload);
            db.SaveChanges();

            return Ok(fileUpload);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FileUploadExists(int id)
        {
            return db.FileUploads.Count(e => e.Id == id) > 0;
        }
    }
}