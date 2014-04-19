using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

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

        public ICollection<string> ListaCorrequisitos
        {
            get
            {
                ICollection<string> lst = new List<string>();
                if (!String.IsNullOrEmpty(CORREQUISITOSASIGNATURA))
                {
                    var corre = CORREQUISITOSASIGNATURA.Split('|');
                    foreach (string idAsignatura in corre)
                    {
                        lst.Add(idAsignatura);
                    }
                }
                return lst;
            }
            set
            {
                foreach (string idAsignatura in value)
                {
                    CORREQUISITOSASIGNATURA = CORREQUISITOSASIGNATURA +"|"+ idAsignatura;
                }
            }
        }
        public ICollection<string> ListaPrerequisitos
        {
            get
            {
                ICollection<string> lst = new List<string>();
                if (!String.IsNullOrEmpty(PREREQUISITOSASIGNATURA))
                {
                    var corre = PREREQUISITOSASIGNATURA.Split('|');
                    foreach (string idAsignatura in corre)
                    {
                        lst.Add(idAsignatura);
                    }
                }
                return lst;
            }
            set
            {
                foreach (string idAsignatura in value)
                {
                    PREREQUISITOSASIGNATURA = PREREQUISITOSASIGNATURA + "|" + idAsignatura;
                }
            }
        }
        public string EdicionOmodificacion { get; set; }

    }
    public class ASIGNATURAMETADATA
    {
        [Required]
        [IDYaExiste(ErrorMessage = "Este id ya esta en uso, ingrese otro")]
        [StringLength(15, ErrorMessage = "El {0} no pueder ser mayor de 15 caracteres")]
        public string IDASIGNATURA { get; set; }
        [Required]
        [StringLength(15, ErrorMessage = "El {0} no pueder ser mayor de 15 caracteres")]
        public string IDPLANESTUDIOS { get; set; }
        [Required]
        [NombreYaExiste(ErrorMessage = "Ingrese otro nombre, ya existe una Asignatura usando ese nombre")]
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
    
    public sealed class NombreYaExiste : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            bool valid = false;
            var asignaturaValidacion = validationContext.ObjectInstance as ASIGNATURA;
            if (value != null)
            {
                var nombre = value as string;
                var db = new GestionProgramasEntities();
                var asignatura = (from e in db.ASIGNATURAs where asignaturaValidacion.IDASIGNATURA  == e.IDASIGNATURA select e).FirstOrDefault();
                if (asignatura != null)
                {
                    if (value.Equals(asignatura.NOMADIGNATURA))
                        valid = true;
                }
                if (valid != true)
                {
                    var nombreAsignatura = (from e in db.ASIGNATURAs where nombre == e.NOMADIGNATURA select e.NOMADIGNATURA).FirstOrDefault
                            ();
                    if (String.IsNullOrEmpty(nombreAsignatura))
                        valid = true;
                }
            }
            return valid ? ValidationResult.Success : new ValidationResult(ErrorMessage);
        }
    }
    public sealed class IDYaExiste : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            bool valid = false;
            var asignaturaValidacion = validationContext.ObjectInstance as ASIGNATURA;
            if (value != null)
            {
                if (asignaturaValidacion.EdicionOmodificacion.Equals("modificacion"))
                {
                    valid = true;
                }
                if (valid != true)
                {
                    var idAsignaturaValor = value as string;
                    var db = new GestionProgramasEntities();
                    var idAsignatura = (from e in db.ASIGNATURAs where idAsignaturaValor == e.IDASIGNATURA select e.IDASIGNATURA).FirstOrDefault
                            ();
                    if (String.IsNullOrEmpty(idAsignatura))
                        valid = true;
                }

            }
            return valid ? ValidationResult.Success : new ValidationResult(ErrorMessage);
        }
    }


}