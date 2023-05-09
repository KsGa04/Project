using System;
using System.Collections.Generic;

namespace Project
{

    public partial class User
    {
        public int UserId { get; set; }

        public string Mail { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string? NikName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public virtual ICollection<Comment> Comments { get; set; } /*= new List<Comment>();*/

        public virtual ICollection<Recipe> Recipes { get; set; } /*= new List<Recipe>();*/
    }
}
