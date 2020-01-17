using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace net_core_bootcamp_b1_ozgun.Models
{
    public class Book
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        [Required, MaxLength(250)]
        public string Name { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string Publisher { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public double Price { get; set; }
    }
}
