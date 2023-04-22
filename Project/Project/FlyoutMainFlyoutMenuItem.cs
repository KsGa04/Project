using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class FlyoutMainFlyoutMenuItem
    {
        public FlyoutMainFlyoutMenuItem()
        {
            TargetType = typeof(FlyoutMainFlyoutMenuItem);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}