using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Project_A.Models
{
    public class NewAssignment
    {
        
        public string Folio { get; set; }
        public DateTime Fecha { get; set; }
        public string NPersonal { get; set; }
        public string Username { get; set; }
        public string Nombre { get; set; }
        public string Sede { get; set; }
        public string Proyecto { get; set; }
        public string Responsable { get; set; }

        public string Tipo { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string NSerie { get; set; }
        public int HDD { get; set; }
        public string Procesador { get; set; }
        public int Memoria { get; set; }
        public string OS { get; set; }
        public string IDTAG { get; set; }
        public string Accesorios { get; set; }
        public string Observaciones { get; set; }
        public string Marca1M { get; set; }
        public string Modelo1M { get; set; }
        public string Serie1M { get; set; }
        public string NoInv1M { get; set; }
        public string Marca2M { get; set; }
        public string Modelo2M { get; set; }
        public string Serie2M { get; set; }
        public string NoInv2M { get; set; }
        public string Marca1T { get; set; }
        public string Modelo1T { get; set; }
        public string Serie1T { get; set; }
        public string NoInv1T { get; set; }
        public string Marca2T { get; set; }
        public string Modelo2T { get; set; }
        public string Serie2T { get; set; }
        public string NoInv2T { get; set; }
        public string FortitokenM { get; set; }
        public string FortitokenNS { get; set; }
        public string OperadorID { get; set; }
        public DateTime FecheRecoleccion { get; set; }
        public string Estado { get; set; }

    }

    
}
