using System;
using System.Collections.Generic;

namespace Project
{

    public partial class Recipe
    {
        public int RecipeId { get; set; }

        public byte[]? ImageRecipe { get; set; }

        public string NameRecipe { get; set; } = null!;

        public string Ingredient { get; set; } = null!;

        public string Description { get; set; } = null!;

        public bool Moder { get; set; }

        public int? UserId { get; set; }

        public int? CategoryId { get; set; }

        public int? MealId { get; set; }

        public virtual ICollection<Comment> Comments { get; set; } /*= new List<Comment>();*/

        public virtual Category? IdCategoryNavigation { get; set; }

        public virtual Meal? IdMealNavigation { get; set; }

        public virtual User? IdUserNavigation { get; set; }
    }
}
