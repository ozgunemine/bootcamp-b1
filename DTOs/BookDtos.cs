using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace net_core_bootcamp_b1_ozgun.DTOs
{
    public class BookAddDto
    {
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

    public class BookUpdateDto : BookAddDto
    {
        [Required]
        public Guid Id { get; set; }
    }
    public class BookGetDto
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public DateTime ReleaseDate { get; set; }
        public double Price { get; set; }
    }
}
