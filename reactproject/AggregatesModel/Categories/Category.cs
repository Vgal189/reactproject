﻿using reactproject.Models;

namespace reactproject.AggregatesModel.Categories
{
    public class Category : Entity
    {
        public Category(string name, List<Category> subcategories)
        {
            Name = name;
            Subcategories = subcategories;
        }

        public string Name { get; set; }
        public List<Category> Subcategories { get; set; }
    }
}
