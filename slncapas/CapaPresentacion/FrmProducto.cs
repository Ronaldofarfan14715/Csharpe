using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidad;
using CapaNegocio;
namespace CapaPresentacion
{
    public partial class FrmProducto : Form
    {
        public FrmProducto()
        {
            InitializeComponent();
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            //Leer los datos
            int id;

            if (txtid.Text.Length == 0){id = 0;}else{id = Convert.ToInt32(txtid.Text);}
            //int id = Convert.ToInt32(txtid.Text);
            string descripcion = txtdescripcion.Text;
            string cateogria = txtcategoria.Text;

            double precio;

            if(txtprecio.Text.Length == 0){precio = 0;} else{ precio = Convert.ToDouble(txtprecio.Text);}
            
            //Instanciar un objeto CE 
            ProductoCE productoCE = new ProductoCE(id,descripcion,cateogria,precio);

            //Instanciar un objeto CN
            ProductoCN productoCN = new ProductoCN();


            if (id == 0)
            {

                //Ejecutar el metodo de agregar
                txtid.Text = productoCN.Nuevo(productoCE).ToString();
                MessageBox.Show("Se ha creado un nuevo producto");
            }
            else
            {   
                //Ejecutar el metodo de actualizacion
                productoCN.Actualizar(productoCE);
                MessageBox.Show("Se ha actualizado el producto");
            }


           
        }

        private void FrmProducto_Load(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (txtid.Text.Length > 0)

            {
                if(MessageBox.Show("ESTA A PUNTO DE ELIMINAR UN REGISTRO. ¿CONTINUAR?","ADVERTENCIA",MessageBoxButtons.YesNo,MessageBoxIcon.Warning,MessageBoxDefaultButton.Button2)==DialogResult.Yes)
                {
                    ProductoCE productoCE = new ProductoCE();
                    productoCE.id = Convert.ToInt32(txtid.Text);

                    ProductoCN productoCN = new ProductoCN();
                    productoCN.Eliminar(productoCE);

                    LimpiarControles();
                }
                
            }
            else
            {
                MessageBox.Show("Debera ingresar un ID");
            }

        }

        private void LimpiarControles()
        {
            foreach (TextBox caja in Controls.OfType<TextBox>())
            {
                caja.Clear();
                txtid.Focus();
            }
        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            LimpiarControles();
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            string micondicion = txtcondicion.Text;
            ProductoCN productoCN = new ProductoCN();

            dgvproductos.DataSource = productoCN.BuscarProducto(micondicion);
        }
    }
}
