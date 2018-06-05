using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class ClienteCN
    {
        ClienteCD clienteCD = new ClienteCD();

        public void Actualizar(ClienteCE clienteCE)
        {
            clienteCD.Actualizar(clienteCE);
        }

        public int Nuevo(ClienteCE clienteCE)
        {
            return clienteCD.Nuevo(clienteCE);
        }

        public void Eliminar(ClienteCE clienteCE)
        {
            clienteCD.Eliminar(clienteCE);
        }
    }
}
