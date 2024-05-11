using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class Course : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public float Price { get; set; }
        public string Instructor { get; set; } = string.Empty;
        public decimal Rating { get; set; }
        public string Image { get; set; } = string.Empty;
        public string SubTitle { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Students { get; set; }
        public string Language { get; set; } = string.Empty;
        public string Level { get; set; } = string.Empty;

        public ICollection<Requirement> Requirements { get; set; } = new List<Requirement>();
        public ICollection<Learning> Learnings { get; set; } = new List<Learning>();
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public DateTime LastUpdated { get; set; } = DateTime.Now;
    }
}
