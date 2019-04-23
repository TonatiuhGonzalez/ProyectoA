using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Project_A.Models
{
    public class Sede
    {
        public int Id { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

    }
}