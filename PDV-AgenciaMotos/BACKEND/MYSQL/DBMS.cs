using CRUD.BD;
using CRUD.Modelo;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace CRUD.Objects
{
    public enum DBMS
    {
        MYSQL,
        MARIABD,
        SQLSERVER,
        MONGODB,
        ORACLE,
        POSTGRESQL,
        INFORMIX
    }
}

