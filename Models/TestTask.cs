using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TestManagerApp.Models
{
    public class TestTask
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public UserControl? TaskContent { get; set; } // Содержимое вкладки
    }
}
