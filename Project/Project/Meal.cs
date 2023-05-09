using System;
using System.Collections.Generic;

namespace Project
{

    public partial class Meal
    {
        public int MealId { get; set; }

        public byte[]? ImageMeal { get; set; }

        public string NameMeal { get; set; } = null!;

        public string? DescriptionMeal { get; set; }

        public int CategoryId { get; set; }

        public virtual Category IdCategoryNavigation { get; set; } = null!;

        public virtual ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();
    }
}