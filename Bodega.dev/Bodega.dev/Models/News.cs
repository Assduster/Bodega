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
        public FileUpload Image { get; set; }
        public int ImageId { get; set; }


    }
    public class FileUpload
    {
        public int Id{get;set;}
        public string imagename {get;set;}
        public byte[] imagedata{get; set;
        } 
    }
}