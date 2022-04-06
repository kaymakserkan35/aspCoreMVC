using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ImageWatermark.Models
{
    public class Image
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string ImageName { get; set; }
        [Column(TypeName = "decimal(18,2")]
        public decimal Price { get; set; }
        [Range(1, 100)]
        public int Stock { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        public string ImagePath { get; set; }
        public string MarkedImagePath { get; set; }
    }
}
