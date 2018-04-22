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
    public partial class FInicio : Form
    {
        private DatosUsuarios datoUsuario;

        public FInicio()
        {
            InitializeComponent();

            datoUsuario = new DatosUsuarios();
        }

        private void FInicio_Load(object sender, EventArgs e)
        {
            //Para mostrar los datos de los usuarios

            dgvUsuarios.DataSource = DatosUsuarios.MOSTRAR();

            //Para ocultar la clave.

            dgvUsuarios.Columns[1].Visible = false;

            //Disfrazar los caracteres escritos en el TextBox TCLAVE

            txtPassword.PasswordChar = '*';
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //Para mostrar los datos de los usuarios
            try{

                DataGridViewRow FILA= dgvUsuarios.CurrentRow;

                //Para copiar los valores de las columnas en las variables US y C
                string US=Convert.ToString(FILA.Cells[0].Value);
                string CL=Convert.ToString(FILA.Cells[1].Value);

                //Para validar el usuario y la contraseña

                if (txtUsuario.Text == US & txtPassword.Text == CL)
                {
                    fMenuPri FP=new fMenuPri();
                    FP.Show();
                    this.Hide();
                }

                else{
                    //Si dejó los campos en blanco.
                    MessageBox.Show("DEBE ESCRIBIR EL NOMBRE DEL USUARIO Y CONTRASEÑA VÁLIDOS");
                }

             }catch {

                //Si el usuario o la contraseña no coinciden o son incorrectos

                MessageBox.Show("USUARIO O CONTRASEÑA INVÁLIDOS");

                txtUsuario.Focus();

                }
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            //Para invocar el método BUSCAR USUARIO

            dgvUsuarios.DataSource = DatosUsuarios.BUSCARPORUSUARIO(txtUsuario.Text);
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            //Para invocar el método BUSCAR CLAVE

            dgvUsuarios.DataSource = DatosUsuarios.BUSCARPORCLAVE(txtPassword.Text);
        }

       
    }
}
