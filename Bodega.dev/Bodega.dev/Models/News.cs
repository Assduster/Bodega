using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bodega.dev.Models
{
    public class News
    {
        public int id { get; set; }
        public string title { get; set; }
        public string text { get; set; }
        public DateTime published { get; set; }
    }
}