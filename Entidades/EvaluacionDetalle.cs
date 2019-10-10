using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class EvaluacionDetalle
    {
        [Key]
        public int id { get; set; }
        public int EvaluacionId { get; set; }
        public string Servicio { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Importe { get; set; }

        public EvaluacionDetalle()
        {
            this.id = 0;
            EvaluacionId = 0;
            Servicio = string.Empty;
            Cantidad = 0;
            Precio = 0;
            Importe = 0;
        }

        public EvaluacionDetalle(int id, int evaluacionId, string servicio, int cantidad, decimal precio, decimal importe)
        {
            this.id = id;
            EvaluacionId = evaluacionId;
            Servicio = servicio;
            Cantidad = cantidad;
            Precio = precio;
            Importe = importe;
        }
    }
}
