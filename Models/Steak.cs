using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WAD.WebApp._10888.Models
{
    public class Steak
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(4)]
        public string Name { get; set; }

        [Required]
        [MinLength(25)]
        public string Description { get; set; }

        public decimal Price { get; set; }
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public SteakSize Size { get; set; }

    }

    public enum SteakSize
    {
        Small,
        Medium,
        Large
    }
}
