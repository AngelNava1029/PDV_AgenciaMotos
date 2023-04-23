using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Modelo
{
    public class Producto
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public float precio { get; set; }
        public int cantidad { get; set; }
        public string tipo { get; set; }
        public string marca { get; set; }
        public string serie { get; set; }
        public string color { get; set; }

        public byte[] imagen { get; set; }
    }

    










}
