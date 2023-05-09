using System;
using System.Collections.Generic;

namespace Project
{

    public partial class Moderator
    {
        public int ModeratorId { get; set; }

        public string Mail { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string? NikName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public int? CategoryId { get; set; }

        public virtual Category? IdCategoryNavigation { get; set; }
    }
}
