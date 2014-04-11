using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIFIET.Presentacion.Models
{
    

        public class USUARIO
        {
            public string IDUSUARIO { get; set; }
            public string EMAILINSTITUCIONALUSUARIO { get; set; }
            public string PASSWORDUSUARIO { get; set; }
            public Nullable<int> IDENTIFICACIONUSUARIO { get; set; }
            public string NOMBRESUSUARIO { get; set; }
            public string APELLIDOSUSUARIO { get; set; }
            public string ESTADO { get; set; }
        }
    
}