using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Objects
{ 

    public abstract class CRUDs_BD
    { 
    protected string connectionString;
    private DBMS dbms;
    protected string tabla;
    protected List<string> campos = new List<string>();
    protected List<string> valores = new List<string>();

    protected string host;
    protected string us;
    protected string pwd;
    protected string puerto;
    protected string nombreBD;

    protected string criteriosBusqueda;

    protected string ordenGruposLimit;

    public string msgError;

    public object dr;

    public abstract bool insertar(string tabla, List<string> campos, List<ValoresAInsertar> valores);
    public abstract bool modificar(string tabla, List<string> campos, List<ValoresAInsertar> valores, int id);
    public abstract bool borrar(string tabla, int id);
    public abstract List<object[]> consulta(string tabla);
    public abstract List<object[]> consulta(string tabla, string criterioBusqueda);

    }
}
