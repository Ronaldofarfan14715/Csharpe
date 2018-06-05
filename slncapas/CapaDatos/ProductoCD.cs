using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class ProductoCD
    {
        public void Actualizar(ProductoCE productoCE)
        {
            //crear mi objeto de conexion
            ConexionCD conexion = new ConexionCD();

            //crear el objeto sqlconnection
            SqlConnection connBD = conexion.ConectarSQLSERVER();
            //abrir la conexion
            connBD.Open();

            //crear un comando
            SqlCommand cmdBD = connBD.CreateCommand();

            //tipo de comando
            cmdBD.CommandType = CommandType.Text;

            //asignar la instruccion SQL

            cmdBD.CommandText = "update producto " + 
                                "set descripcion=@descripcion, categoria=@categoria, precio=@precio " +
                                "where id=@id";

            //Asigno parametros y sus valores
            cmdBD.Parameters.AddWithValue("@descripcion", productoCE.descripcion);
            cmdBD.Parameters.AddWithValue("@categoria",productoCE.categoria);
            cmdBD.Parameters.AddWithValue("@precio", productoCE.precio);
            cmdBD.Parameters.AddWithValue("@id", productoCE.id);

            //EJERCUTAR EL COMMAND
            cmdBD.ExecuteNonQuery();

            //CERRAR LA CONEXION
            connBD.Close();

        }

        public int Nuevo(ProductoCE productoCE)
        {
            //crear mi objeto de conexion
            ConexionCD conexion = new ConexionCD();

            //crear el objeto sqlconnection
            SqlConnection connBD = conexion.ConectarSQLSERVER();
            //abrir la conexion
            connBD.Open();

            //crear un comando
            SqlCommand cmdBD = connBD.CreateCommand();

            //tipo de comando
            cmdBD.CommandType = CommandType.Text;

            //asignar la instruccion SQL

            cmdBD.CommandText = "insert into producto (descripcion, categoria, precio) " +
                                "values (@descripcion, @categoria, @precio)";
                                

            //Asigno parametros y sus valores
            cmdBD.Parameters.AddWithValue("@descripcion", productoCE.descripcion);
            cmdBD.Parameters.AddWithValue("@categoria", productoCE.categoria);
            cmdBD.Parameters.AddWithValue("@precio", productoCE.precio);

            //EJERCUTAR EL COMMAND
            cmdBD.ExecuteNonQuery();

            //DETERMINAR EL ULTIMO ID
            cmdBD.CommandText = "select  max(id) as nuevoId from producto where descripcion=@descripcion";

            //ASIGNAR VALOR AL PARAMETRO YA CREADO(DESCRIPCION) 

            cmdBD.Parameters["@descripcion"].Value = productoCE.descripcion;

            //DETERMINAR EL ULTIMO ID
            //EJECUTAR EL COMANDO

            SqlDataReader drBD = cmdBD.ExecuteReader();

            //LEER EL DATAREADER

            drBD.Read();

            //LEER EL VALOR  DE LA COLUMNA EN EL DATAREADER

            productoCE.id =Convert.ToInt32(drBD["nuevoId"].ToString());

            //CERRAR LA CONEXION
            connBD.Close();

            return productoCE.id;

        }

        public void Eliminar(ProductoCE productoCE)
        {

            //crear mi objeto de conexion
            ConexionCD conexion = new ConexionCD();

            //crear el objeto sqlconnection
            SqlConnection connBD = conexion.ConectarSQLSERVER();
            //abrir la conexion
            connBD.Open();

            //crear un comando
            SqlCommand cmdBD = connBD.CreateCommand();

            //tipo de comando
            cmdBD.CommandType = CommandType.Text;

            //asignar la instruccion SQL

            cmdBD.CommandText = "delete producto where id=@id";
                                

            //Asigno parametros y sus valores
            
            cmdBD.Parameters.AddWithValue("@id", productoCE.id);

            //EJERCUTAR EL COMMAND
            cmdBD.ExecuteNonQuery();

            //CERRAR LA CONEXION
            connBD.Close();


        }
        public List<ProductoCE> BuscarProducto(string condicion)
        {
            //crear mi objeto de conexion
            ConexionCD conexion = new ConexionCD();

            //crear el objeto sqlconnection
            SqlConnection connBD = conexion.ConectarSQLSERVER();
            //abrir la conexion
            connBD.Open();

            //crear un comando
            SqlCommand cmdBD = connBD.CreateCommand();

            //tipo de comando
            cmdBD.CommandType = CommandType.Text;

            //asignar la instruccion SQL

            cmdBD.CommandText = "select * from producto where descripcion like '%' + @descripcion + '%'";

            //Asignar parametros y sus valores

            cmdBD.Parameters.AddWithValue("@descripcion",condicion);

            //Ejecutar el comando y asignar el resultado a un sqldatareader 

            SqlDataReader drBD = cmdBD.ExecuteReader();

            //Declarar la coleccion 
            List<ProductoCE> miListaProductos = new List<ProductoCE>();

            //Leer el sqldatareader hasta finalizar el EOF

            while (drBD.Read())
            {
                //Instanciar un objeto ProductoCE
                ProductoCE productoCE = new ProductoCE();

                //Asignar los valores a la propiedades
                productoCE.id = Convert.ToInt32(drBD["id"].ToString());
                productoCE.descripcion = drBD["descripcion"].ToString();
                productoCE.categoria = drBD["categoria"].ToString();
                productoCE.precio = Convert.ToDouble(drBD["precio"].ToString());


                //Agregar el elemnto a la coleccion MilistaProductos

                miListaProductos.Add(productoCE);

                
            }
            connBD.Close();
            return miListaProductos;

        }
    }
}
