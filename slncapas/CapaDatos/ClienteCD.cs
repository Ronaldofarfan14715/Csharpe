using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using CapaEntidad;
namespace CapaDatos
{
    public class ClienteCD
    {
        public void Actualizar(ClienteCE clienteCE)
        {
            ConexionCD conexion = new ConexionCD();

            SqlConnection connBD = conexion.ConectarSQLSERVER();

            connBD.Open();


            SqlCommand cmd = connBD.CreateCommand();

            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "update cliente " +
                               "set nombre=@nombre, numruc=@numruc, direccion=@direccion, telefono=@telefono " +
                               "where id=@id";

            

            cmd.Parameters.AddWithValue("@numruc", clienteCE.numruc);
            cmd.Parameters.AddWithValue("@nombre", clienteCE.nombre);
            cmd.Parameters.AddWithValue("@direccion", clienteCE.direccion);
            cmd.Parameters.AddWithValue("@telefono", clienteCE.telefono);
            cmd.Parameters.AddWithValue("@id", clienteCE.id);

            cmd.ExecuteNonQuery();

            connBD.Close();

        }

        public int Nuevo(ClienteCE clienteCE)
        {
            ConexionCD conexion = new ConexionCD();

            SqlConnection connBD = conexion.ConectarSQLSERVER();

            connBD.Open();


            SqlCommand cmd = connBD.CreateCommand();

            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "insert into cliente (nombre, numruc, direccion,telefono) " +
                               "values (@nombre, @numruc, @direccion,@telefono)";


            cmd.Parameters.AddWithValue("@nombre", clienteCE.nombre);
            cmd.Parameters.AddWithValue("@numruc", clienteCE.numruc);
            cmd.Parameters.AddWithValue("@direccion", clienteCE.direccion);
            cmd.Parameters.AddWithValue("@telefono", clienteCE.telefono);
           

            cmd.ExecuteNonQuery();

            cmd.CommandText = "select max(id) as nuevoId from cliente where nombre=@nombre";

            cmd.Parameters["@nombre"].Value = clienteCE.nombre;

            SqlDataReader drBD = cmd.ExecuteReader();

            drBD.Read();

            clienteCE.id = Convert.ToInt32(drBD["nuevoId"].ToString());

            connBD.Close();

            return clienteCE.id;

        }

        public void Eliminar(ClienteCE clienteCE)
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

            cmdBD.CommandText = "delete cliente where id=@id";


            //Asigno parametros y sus valores

            cmdBD.Parameters.AddWithValue("@id", clienteCE.id);

            //EJERCUTAR EL COMMAND
            cmdBD.ExecuteNonQuery();

            //CERRAR LA CONEXION
            connBD.Close();


        }

    }
}
