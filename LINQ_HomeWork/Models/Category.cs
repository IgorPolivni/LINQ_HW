using System;
using System.Collections.Generic;
using System.Text;

namespace LINQ_HomeWork.Models
{
    public class Category
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
    }
}
