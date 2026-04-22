using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD_Navigation.Models
{
    public class ElementWithID
    {
        public ElementWithID(int id, string name,string type, string description)
        {
            ID = id;
            Name = name;
            Type = type;
            Description = description;
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
    }
}
