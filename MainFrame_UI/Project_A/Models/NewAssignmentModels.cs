using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_A.Models
{
    public class NewAssignmentModels
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Proyecto { get; set; }

        public Sede Sede { get; set; }

        public Responsable Responsable { get; set; }

        
    }
}