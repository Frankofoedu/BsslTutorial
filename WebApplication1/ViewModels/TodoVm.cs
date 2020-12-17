using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.ViewModels
{
    public class TodoVm
    {
        public int Id { get; set; }
        public string TodoDescription { get; set; }
        public string TodoTime { get; set; }
        public bool IsDone { get; set; }

    }
}
