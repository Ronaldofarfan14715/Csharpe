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
    public partial class FrmCliente : Form
    {
        public FrmCliente()
        {
            InitializeComponent();
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            int id;

            if(txtid.Text.Length == 0) { id = 0; } else { id = Convert.ToInt32(txtid.Text);}
           

            string nombre = txtnombre.Text;
            string ruc = txtruc.Text;
            string direccion = txtdireccion.Text;
            string telefono = txttelefono.Text;

            ClienteCE clienteCE = new ClienteCE(id,nombre,ruc, direccion, telefono);

            ClienteCN clienteCN = new ClienteCN();

            if (id == 0)
            {
                txtid.Text = clienteCN.Nuevo(clienteCE).ToString();
                MessageBox.Show("Se ha creado un nuevo cliente");
            }
            else
            {

                clienteCN.Actualizar(clienteCE);
                MessageBox.Show("Se ha actualizado un cliente");

            }

     


        }

        private void FrmCliente_Load(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (txtid.Text.Length > 0)

            {
                if (MessageBox.Show("ESTA A PUNTO DE ELIMINAR UN REGISTRO. ¿CONTINUAR?", "ADVERTENCIA", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    ClienteCE clienteCE = new ClienteCE();
                    clienteCE.id = Convert.ToInt32(txtid.Text);

                    ClienteCN clienteCN = new ClienteCN();
                    clienteCN.Eliminar(clienteCE);

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

        private void btnnuevo_Click(object sender, EventArgs e)
        {
            LimpiarControles();
        }
    }
}
