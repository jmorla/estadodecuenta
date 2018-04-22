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
    public partial class fModificarProv : Form
    {
        private String codigo;
        public fModificarProv(String codigo)
        {
            InitializeComponent();
            this.codigo = codigo;
        }

        private void fModificarProv_Load(object sender, EventArgs e)
        {
            PROVEEDORES prov = DatosProveedores.CARGAR(this.codigo);

            this.codigo = prov.CODIGO;

            txtCodigo.Text = this.codigo;

            txtNombres.Text = prov.NOMBRES;

            txtDireccion.Text = prov.DIRECCION;

            txtCiudad.Text = prov.CIUDAD;

            txtTelefono.Text = prov.TELEFONO;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Invocamos el método MODIFICARPROVEEDOR.

            DatosProveedores.MODIFICARPEOVEEDOR
            (this.codigo, txtNombres.Text,

            txtApellidos.Text,

            txtDireccion.Text, txtDireccion.Text,

            txtTelefono.Text);

            MessageBox.Show("EL REGISTRO SE MODIFICÓ EXITOSAMENTE.", "MODIFICACIÓN");
            
            Close();
         }
    }
}
