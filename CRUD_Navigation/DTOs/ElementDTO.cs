using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CRUD_Navigation.DTOs
{
    public class ElementDTO
    {
        [Key]
        public int Id {  get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }


    }
}
