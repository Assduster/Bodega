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
        [Display(Name = "Titel")]
        public string Title { get; set; }
        [Display(Name = "Nyhets Text")]
        public string Text { get; set; }
        public DateTime Published { get; set; }
    }
   
}