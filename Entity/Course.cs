using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Course
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public float Price { get; set; }
        public string Instructor { get; set; } = string.Empty;
        public decimal Rating { get; set; }
        public string Image { get; set; } = string.Empty;
    }
}
