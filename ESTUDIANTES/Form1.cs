using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ESTUDIANTES
{
    public partial class Form1 : Form
    {
        String usuario, password;
        basedatos basedatos = new basedatos();
        
        public Form1()
        {
            InitializeComponent();
            txtusuario.Focus();
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            MessageBox.Show("FUE UN GUSTO CONOCERLO");
            Application.Exit();
        }

        private void btningresar_Click(object sender, EventArgs e)
        {
            usuario = txtusuario.Text;
            password = txtclave.Text;

            if (basedatos.Conectarbd(usuario, password))
            {
                MessageBox.Show("BIENVENIDO " + usuario);
                this.Hide();
                FrmPrincipal frmprincipal = new FrmPrincipal();
                frmprincipal.Visible = true;
                frmprincipal.Show();

            }
            else
            {
                MessageBox.Show("DATOS INGRESADOS INCORRECTAMENTE");
                txtusuario.Clear();
                txtclave.Clear();
                txtusuario.Focus();
            }
            
        }
    }
}
