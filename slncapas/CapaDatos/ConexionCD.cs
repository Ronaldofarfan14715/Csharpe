using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//AGREGAR NAMESPACE
using System.Data.SqlClient;
namespace CapaDatos
{
    public class ConexionCD
    {
        public SqlConnection ConectarSQLSERVER()
        {


            //INSTANCIAR UN OBJETO SQLCONNECTIONSTRINBUILDER
            SqlConnectionStringBuilder cadenaConexion = new SqlConnectionStringBuilder();
            cadenaConexion.DataSource = @"DESKTOP-QDCMGIV\MS_SQL";
            cadenaConexion.InitialCatalog = "BD_201810FE401";
            cadenaConexion.UserID = "sa";
            cadenaConexion.Password = "181003";


            //CREAR EL OBJETO DE CONEXION SQLCONNECTION

            SqlConnection connBD = new SqlConnection(cadenaConexion.ConnectionString);

            //RETORNAR EL SQLCONNECTION
            return connBD;


        }
    }
}
