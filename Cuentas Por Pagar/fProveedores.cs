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

        fAgregarProv fb = new fAgregarProv();

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

        private void fProveedores_FormClosed(object sender, FormClosedEventArgs e)
        {
            dgProveedores.DataSource = DatosProveedores.MOSTRARDATOS();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Creamos una instancia tipo FMODIFICARPROV

            fAgregarProv FMP = new fAgregarProv();

            /*Abrimos el formulario y actualizamos DataGrid View DGVPROVEEDORES  después de cerrarlo */
            this.Hide();
            FMP.FormClosed += new

            System.Windows.Forms.FormClosedEventHandler(fProveedores_FormClosed); FMP.Show();
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {

                txtNombres.Focus();

            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            DataGridViewRow FILA = dgProveedores.CurrentRow;
            string codigo = "NON";
            try
            {
                codigo = Convert.ToString(FILA.Cells[0].Value);
            }
            catch {
                MessageBox.Show("Seleccione un registro!");
                return;
            }
            fModificarProv FMP = new fModificarProv(codigo);

            FMP.FormClosed += new

            System.Windows.Forms.FormClosedEventHandler(fProveedores_FormClosed);
            this.Hide();
            FMP.Show();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("Desea eliminar el proveedor?", "Eliminar", MessageBoxButtons.YesNo);
            if (respuesta == DialogResult.Yes)

            {
                DataGridViewRow FILA = dgProveedores.CurrentRow; 
                string codigo = Convert.ToString(FILA.Cells[0].Value);

                DatosProveedores.ELIMINARPROVEEDOR(codigo);

                MessageBox.Show("SE HA BORRADO EL PROVEEDOR" +txtNombres.Text +" "+ txtApellidos.Text, "REGISTRO ELIMINADO");
                DatosProveedores.MOSTRARDATOS();

                dgProveedores.DataSource = DatosProveedores.MOSTRARDATOS();

                //OCULTAMOS LA COLUMNA FACTURAS PARA QUE NO APAREZCA EN EL DATAGRID VIEW.

                dgProveedores.Columns["FACTURAS"].Visible = false;
            }
        }
    }
}
