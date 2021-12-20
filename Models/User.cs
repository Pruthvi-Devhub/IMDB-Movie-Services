using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IMDBService.Models
{
    public class User
    {

        [Key]
        public int userId { get; set; }

        [Required]
        public string username { get; set; }
        [Required]
        public string useremail { get; set; }
        [Required]
        public string Favouritegenre { get; set; }
    }
}
