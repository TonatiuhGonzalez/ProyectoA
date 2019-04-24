using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Project_A.Models
{
    public class NewAssignment
    {
        public int ID { get; set; }
        public string Folio { get; set; }
        public DateTime Fecha { get; set; }
        public string NPersonal { get; set; }
        public string Username { get; set; }
        public string Nombre { get; set; }
        public string Sede { get; set; }
        public string Proyecto { get; set; }
        public string Responsable { get; set; }

    }

    
}
