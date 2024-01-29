using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ESTUDIANTES
{
    public partial class FrmPrincipal : Form
    {
        Conexion conexion = new Conexion();
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            Conexion.Conectar();
            dataGridView1.DataSource = llenar_grid();
        }

        public DataTable llenar_grid()
        {
            Conexion.Conectar();
            DataTable dt = new DataTable();
            string consulta = "SELECT * FROM ALUMNO";
            SqlCommand cmd = new SqlCommand(consulta, Conexion.Conectar());
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(dt);
            return dt;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // Validar campos obligatorios
            if (string.IsNullOrEmpty(txtcodigo.Text))
            {
                MessageBox.Show("El campo Código es obligatorio");
                return;
                
            }
            else if (string.IsNullOrEmpty(txtprimernombre.Text))
            {
                MessageBox.Show("El campo Primer Nombre es obligatorio");
                return;
            }
            else if (string.IsNullOrEmpty(txtprimerapellido.Text))
            {
                MessageBox.Show("El campo Primer Apellido es obligatorio");
                return;
            }
            else if (string.IsNullOrEmpty(txtsegundoapellido.Text))
            {
                MessageBox.Show("El campo Segundo Apellido es obligatorio");
                return;
            }
            else if (string.IsNullOrEmpty(txtcelular.Text))
            {
                MessageBox.Show("El campo Celular es obligatorio");
                return;
            }
            else if (string.IsNullOrEmpty(txtdireccion.Text))
            {
                MessageBox.Show("El campo Dirección es obligatorio");
                return;
            }
            else if (string.IsNullOrEmpty(txtemail.Text))
            {
                MessageBox.Show("El campo Email es obligatorio");
                return;
            }
            else if (string.IsNullOrEmpty(txtfechanac.Text))
            {
                MessageBox.Show("El campo Fecha de Nacimiento es obligatorio");
                return;
            }

            string codigo = txtcodigo.Text;
            string prinom= txtprimernombre.Text;
            string segnom=  txtsegundonombre.Text;
            string priapell= txtprimerapellido.Text;
            string segapell= txtsegundoapellido.Text;
            string telefono = txttelefono.Text;
            int celular = Convert.ToInt32(txtcelular.Text);
            string direccion = txtdireccion.Text;
            string email = txtemail.Text;
            DateTime fecha = Convert.ToDateTime(txtfechanac.Text);
            string observacion = txtobser.Text;
            int nota = Convert.ToInt16(txtnota.Text);

            if (conexion.Insertar(codigo, prinom, segnom, priapell, segapell, telefono, celular, direccion, email, fecha, observacion, nota))
            {
                MessageBox.Show("Los datos se agregaron correctamente");
                dataGridView1.DataSource = llenar_grid();
            } 

        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtcodigo.Text))
            {
                MessageBox.Show("El campo Código es obligatorio");
                return;

            }
            else if (string.IsNullOrEmpty(txtprimernombre.Text))
            {
                MessageBox.Show("El campo Primer Nombre es obligatorio");
                return;
            }
            else if (string.IsNullOrEmpty(txtprimerapellido.Text))
            {
                MessageBox.Show("El campo Primer Apellido es obligatorio");
                return;
            }
            else if (string.IsNullOrEmpty(txtsegundoapellido.Text))
            {
                MessageBox.Show("El campo Segundo Apellido es obligatorio");
                return;
            }
            else if (string.IsNullOrEmpty(txtcelular.Text))
            {
                MessageBox.Show("El campo Celular es obligatorio");
                return;
            }
            else if (string.IsNullOrEmpty(txtdireccion.Text))
            {
                MessageBox.Show("El campo Dirección es obligatorio");
                return;
            }
            else if (string.IsNullOrEmpty(txtemail.Text))
            {
                MessageBox.Show("El campo Email es obligatorio");
                return;
            }
            else if (string.IsNullOrEmpty(txtfechanac.Text))
            {
                MessageBox.Show("El campo Fecha de Nacimiento es obligatorio");
                return;
            }


            string codigo = txtcodigo.Text;
            string prinom = txtprimernombre.Text;
            string segnom = txtsegundonombre.Text;
            string priapell = txtprimerapellido.Text;
            string segapell = txtsegundoapellido.Text;
            string telefono = txttelefono.Text;
            int celular = Convert.ToInt32(txtcelular.Text);
            string direccion = txtdireccion.Text;
            string email = txtemail.Text;
            DateTime fecha = Convert.ToDateTime(txtfechanac.Text);
            string observacion = txtobser.Text;
            int nota = Convert.ToInt16(txtnota.Text);

            if (conexion.Actualizar(codigo, prinom, segnom, priapell, segapell, telefono, celular, direccion, email, fecha, observacion, nota))
            {
                MessageBox.Show("Registro actualizado");
                dataGridView1.DataSource = llenar_grid();
            }
               
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtcodigo.Text))
            {
                MessageBox.Show("El campo Código es obligatorio");
                return;
            }

            int codigo;
            codigo = Convert.ToInt16(txtcodigo.Text);
            if (conexion.Eliminar(codigo))
            {
                MessageBox.Show("Los datos fueron eliminados correctamente");
                dataGridView1.DataSource = llenar_grid();
            } 
            else
                MessageBox.Show("Error al eliminar ");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtcodigo.Text = "";
            txtprimernombre.Text = "";
            txtsegundonombre.Text = "";
            txtprimerapellido.Text = "";
            txtsegundoapellido.Text = "";
            txttelefono.Text = "";
            txtcelular.Text = "";
            txtdireccion.Text = "";
            txtemail.Text = "";
            txtfechanac.Text = "";
            txtobser.Text = "";
            txtnota.Text = "";

            txtcodigo.Focus();

            dataGridView1.DataSource = llenar_grid();
        }


        private void button5_Click(object sender, EventArgs e)
        {
            ReporteEstudiante reporte = new ReporteEstudiante();
            reporte.ShowDialog();

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            { 

                txtcodigo.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtprimernombre.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtsegundonombre.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txtprimerapellido.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                txtsegundoapellido.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                txttelefono.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                txtcelular.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                txtdireccion.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                txtemail.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                txtfechanac.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
                txtobser.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
                txtnota.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();

            }
            catch { }
        }

        private void txtsalir_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 frm = new Form1();
            frm.Show();
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtcodigo.Text))
            {
                MessageBox.Show("El campo Código es obligatorio");
                return;
            }
            string codigo = txtcodigo.Text;
            DataTable lstauxiliar = conexion.Buscar(codigo);
            dataGridView1.DataSource = lstauxiliar;
        }
    }
}
