using LINQ_HomeWork.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LINQ_HomeWork.DataClasses
{
    public abstract class Product
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public double Price { get; set; }

        //Производитель
        public string Producer { get; set; }

        //Дата производства
        public DateTime dateProduction { get; set; } = DateTime.Now;

        public Guid CategoryId { get; set; }

        public Category Category { get; set; }

    }
}
