using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cookye.Models
{
    public class Personne
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Login { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Password { get; set; }

    }
}