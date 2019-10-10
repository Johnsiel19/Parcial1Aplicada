using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class Evaluacion
    {
        [Key]

        public int EvaluacionId { get; set; }
        public string Estudiante { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
       public virtual List<EvaluacionDetalle> Detalles { get; set; }

        public Evaluacion()
        {
            EvaluacionId = 0;
            Estudiante = string.Empty;
            Fecha = DateTime.Now;
            Total = 0;
            Detalles = new List<EvaluacionDetalle>();
        }
    }
}
