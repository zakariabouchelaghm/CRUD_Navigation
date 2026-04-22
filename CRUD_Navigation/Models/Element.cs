using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD_Navigation.Models
{
    public class Element
    {


        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }

        public Element(string name, string type, string description)
        {
            Name = name;
            Type = type;
            Description = description;
        }

    }
}
