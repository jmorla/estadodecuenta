﻿using System;
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
    public partial class fMenuPri : Form
    {
        

        public fMenuPri()
        {
            InitializeComponent();
        }

        private void mantenimientoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fProveedores fp = new fProveedores();

            fp.Show();

        }
    }
}
