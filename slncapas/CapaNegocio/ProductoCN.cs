using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;


namespace CapaNegocio
{
    public class ProductoCN


    {
        //INSTANCIAR PRODUCTO DE LA CAPA DATOS
        ProductoCD productoCD = new ProductoCD();


        //DECLARAR METODO QUE INVOCA A LOS METODOS DE LA CAPADATOS
        public void Actualizar(ProductoCE productoCE)
        {
            productoCD.Actualizar(productoCE);
        }

        public int Nuevo(ProductoCE productoCE)
        {
            return productoCD.Nuevo(productoCE);
        }

        public void Eliminar(ProductoCE productoCE)
        {
            productoCD.Eliminar(productoCE);
        }

        public List<ProductoCE> BuscarProducto(string condicion)
        {
            return productoCD.BuscarProducto(condicion);
        }
    }
}
