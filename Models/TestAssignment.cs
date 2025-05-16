using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestManagerApp.Models
{
    public class TestAssignment
    {
        public Guid Id { get; set; }
        public string Description { get; set; } = "";
        public string ProjectPath { get; set; } = "";
        public DateTime DateTimeAdded { get; set; }
        public bool IsCompleted { get; set; }
    }
}
