//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SIFIET.GestionProgramas.Datos.Modelo
{
    using System;
    using System.Collections.Generic;
    
    public partial class PROGRAMA
    {
        public PROGRAMA()
        {
            this.PLANESTUDIOS = new HashSet<PLANESTUDIO>();
        }
    
        public string IDPROGRAMA { get; set; }
        public string IDFACULTAD { get; set; }
        public string NOMPROGRAMA { get; set; }
        public string DESCPROGRAMA { get; set; }
        public string JORNANADAPROGRAMA { get; set; }
        public Nullable<decimal> DURACIONPROGRAMA { get; set; }
        public string ADMISIONPROGRAMA { get; set; }
        public Nullable<decimal> CODIGOSNIES { get; set; }
        public string PERIODODURACION { get; set; }
        public string ESTADOPROGRAMA { get; set; }
    
        public virtual ICollection<PLANESTUDIO> PLANESTUDIOS { get; set; }
    }
}
