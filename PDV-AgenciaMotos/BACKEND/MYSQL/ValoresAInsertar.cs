using CRUD.BD;
using CRUD.Modelo;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD.MySQL
{
    public class ValoresAInsertar
    {
        public string valor;
        public bool llevaApostrofes;

        public ValoresAInsertar(string v, bool llevaApostrofes = true)
        {
            this.valor = v;
            this.llevaApostrofes = llevaApostrofes;
        }
    }
}

