using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace WAD.WebApp._10888.DAL.DBO
{
    public class Steak
    {
        public int Id { get; set; }

        [Required]
        [MinLength(4)]
        public string Name { get; set; }

        [Required]
        [MinLength(25)]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }


        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        [Required]
        public SteakSize Size { get; set; }

        [Display(Name = "Photo")]
        public byte[] BinaryPhoto { get; set; }


        [Display(Name = "Photo")]
        [DataType(DataType.Upload)]
        [NotMapped]
        public IFormFile SteakPhoto { get; set; }

    }

    public enum SteakSize
    {
        Small,
        Medium,
        Large
    }
}
