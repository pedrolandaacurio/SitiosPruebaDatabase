//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SitiosPruebaMVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Informante
    {
        public int Id_Informante { get; set; }
        public string Nombres { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public Nullable<int> Id_Sitio { get; set; }
    
        public virtual Sitio Sitio { get; set; }
    }
}