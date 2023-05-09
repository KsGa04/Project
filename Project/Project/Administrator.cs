using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project {

    public partial class Administrator
    {
        public int AdministratorId { get; set; }

        public string Mail { get; set; } = null!;

        public string Password { get; set; } = null!;
        
    }
}
