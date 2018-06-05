using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
   public class ClienteCE
    {
        public int id { get; set; }

        public string nombre { get; set; }
        public string numruc { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }

        public ClienteCE()
        {

        }
        public ClienteCE(int idx,string nombrex,string numrucx,string direccionx,string telefonox)
        {
            this.id = idx;
            this.nombre = nombrex;
            this.numruc = numrucx;
            this.direccion = direccionx;
            this.telefono = telefonox;

        }
    }
}
