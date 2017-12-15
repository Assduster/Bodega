using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Bodega.dev.Models
{
    public class News
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime Published { get; set; }
        public ImageUpload ImageUploads { get; set; }

        [NotMapped]
        public int ImageUploadId { get; set; }

        public News()
        {

        }
      
    }
 
}