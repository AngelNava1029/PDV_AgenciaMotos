using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Objects
{
    public class Venta
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public double subtotal { get; set; }
        public string fecha { get; set; }
        public string cantidad { get; set; }
        public int id_producto { get; set; }

        
    }

    public class VentaDetalle
    {
        public int IdVenta { get; set; }
        public int ProductoId { get; set; }
        public string fecha { get; set; }
        public double subtotal { get; set; }
        public int id{ get; set; }
        public float Monto { get; set; }

    }
}
