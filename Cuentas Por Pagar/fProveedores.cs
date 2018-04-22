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
    public partial class fProveedores : Form
    {
        public fProveedores()
        {
            InitializeComponent();
        }

        private void fProveedores_Load(object sender, EventArgs e)
        {
            //INVOCAMOS EL MÉTODO  MÉTODO MOSTRARPROVEEDORES DE LA CLASE DATOSPROVEEDORES

            dgProveedores.DataSource = DatosProveedores.MOSTRARDATOS();

            //OCULTAMOS LA COLUMNA FACTURAS PARA QUE NO APAREZCA EN EL DATAGRID VIEW.

            dgProveedores.Columns["FACTURAS"].Visible = false;
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            dgProveedores.DataSource = DatosProveedores.BUSCARPORCODIGO(txtCodigo.Text);
        }

        private void txtNombres_TextChanged(object sender, EventArgs e)
        {
            dgProveedores.DataSource = DatosProveedores.BUSCARNOMBRES(txtNombres.Text);
        }

        private void txtApellidos_TextChanged(object sender, EventArgs e)
        {
            dgProveedores.DataSource = DatosProveedores.BUSCARPORAPELLIDOS(txtApellidos.Text);
        }

        private void txtDireccion_TextChanged(object sender, EventArgs e)
        {
            dgProveedores.DataSource = DatosProveedores.BUSCARPORDIRECCION(txtDireccion.Text);
        }

        private void txtCiudad_TextChanged(object sender, EventArgs e)
        {
            dgProveedores.DataSource = DatosProveedores.BUSCARPORCIUDAD(txtCodigo.Text);
        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
