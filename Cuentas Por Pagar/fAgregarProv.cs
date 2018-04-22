using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cuentas_Por_Pagar
{
    public partial class fAgregarProv : Form
    {
        public fAgregarProv()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DatosProveedores.INSERTARPROVEEDOR(

            txtCodigo.Text,
            txtNombres.Text,
            txtApellidos.Text,
            txtDireccion.Text,
            txtCiudad.Text,
            txtTelefono.Text);

            MessageBox.Show("EL PROVEEDOR"+" "+txtNombres.Text+" "+txtApellidos.Text+" "+
                "HA SIDO AGREGADO", "AGREGAR PROVEEDOR");
            this.Close();
        }
    }
}
