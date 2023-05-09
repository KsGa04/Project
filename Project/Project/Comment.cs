using System;
using System.Collections.Generic;

namespace Project
{

    public partial class Comment
    {
        public int CommentId { get; set; }

        public string NameComment { get; set; } = null!;

        public DateTime DateComement { get; set; }

        public int UserId { get; set; }

        public int RecipeId { get; set; }

        public virtual Recipe IdRecipeNavigation { get; set; } = null!;

        public virtual User IdUserNavigation { get; set; } = null!;
    }
}
