using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace SIFIET.GestionProgramas.Datos.Modelo
{
    [MetadataType(typeof(ASIGNATURAMETADATA))]
    public partial class ASIGNATURA
    {
        public string NombrePlaneEstudio
        {
            get
            {
                var db = new GestionProgramasEntities();
                return (from e in db.PLANESTUDIOS where IDPLANESTUDIOS == e.IDPLANESTUDIOS select e.NOMPLANESTUDIOS).First();
            
            }
        }
    }
    public class ASIGNATURAMETADATA
    {
        [Required]
        [StringLength(15, ErrorMessage = "El {0} no pueder ser mayor de 15 caracteres")]
        public string IDASIGNATURA { get; set; }
        [Required]
        [StringLength(15, ErrorMessage = "El {0} no pueder ser mayor de 15 caracteres")]
        public string IDPLANESTUDIOS { get; set; }
        [Required]
        [StringLength(120, ErrorMessage = "El {0} no pueder ser mayor de 120 caracteres")]
        public string NOMADIGNATURA { get; set; }
        
        [StringLength(250, ErrorMessage = "El {0} no pueder ser mayor de 250 caracteres")]
        public string CORREQUISITOSASIGNATURA { get; set; }
        
        [StringLength(250, ErrorMessage = "El {0} no pueder ser mayor de 250 caracteres")]
        public string PREREQUISITOSASIGNATURA { get; set; }
        [Required]
        public Nullable<short> SEMESTREASIGNATURA { get; set; }
        [Required]
        public Nullable<decimal> INTENSIDADHORARIA { get; set; }
        [Required]
        [StringLength(15, ErrorMessage = "El {0} no pueder ser mayor de 15 caracteres")]
        public string MODALIDAD { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "El {0} no pueder ser mayor de 50 caracteres")]
        public string CLASIFICACION { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "El {0} no pueder ser mayor de 50 caracteres")]
        public string ESTADOASIGNATURA { get; set; }

    }
}
