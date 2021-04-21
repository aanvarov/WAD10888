using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace WAD.WebApp._10888.DAL.DBO
{
    public class Category
    {
        public int Id { get; set; }

        [DisplayName("Category")]
        public string CategoryName { get; set; }
    }
}
