using System;
using System.Data.Entity;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel;

namespace CaioComputers.Models
{
    public class Category
    {
        public int Id { get; set; }

        [DisplayName("Category Name")]
        [StringLength(maximumLength: 20, ErrorMessage = "You can enter a maximum of 20 characters")]
        public string Name { get; set; }
        public string Description { get; set; }

        public List<Product> Products { get; set; }
    }
}