using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IMDBService.Models
{
    public class Movie
    {
        [Key]
        public int movieId { get; set; }

        [Required]
        public string moviename { get; set; }

        [Required]
        public string genre { get; set; }

        [Required]
        public DateTime releasedate { get; set; }

        public string reviews { get; set; }

        public int upvotes { get; set; }

        public int downvotes { get; set; }
    }
}
