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
    public partial class ReporteEstudiante : Form
    {
        public ReporteEstudiante()
        {
            InitializeComponent();
        }

        private void ReporteEstudiante_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'REGISTRODataSet.listado' Puede moverla o quitarla según sea necesario.
            this.listadoTableAdapter.Fill(this.REGISTRODataSet.listado);

            this.reportViewer1.RefreshReport();
            
        }
    }
}
