
namespace ESTUDIANTES
{
    partial class ReporteEstudiante
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReporteEstudiante));
            this.listadoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.REGISTRODataSet = new ESTUDIANTES.REGISTRODataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.listadoTableAdapter = new ESTUDIANTES.REGISTRODataSetTableAdapters.listadoTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.listadoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.REGISTRODataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // listadoBindingSource
            // 
            this.listadoBindingSource.DataMember = "listado";
            this.listadoBindingSource.DataSource = this.REGISTRODataSet;
            // 
            // REGISTRODataSet
            // 
            this.REGISTRODataSet.DataSetName = "REGISTRODataSet";
            this.REGISTRODataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.listadoBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "ESTUDIANTES.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(979, 507);
            this.reportViewer1.TabIndex = 0;
            // 
            // listadoTableAdapter
            // 
            this.listadoTableAdapter.ClearBeforeFill = true;
            // 
            // ReporteEstudiante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 507);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReporteEstudiante";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReporteEstudiante";
            this.Load += new System.EventHandler(this.ReporteEstudiante_Load);
            ((System.ComponentModel.ISupportInitialize)(this.listadoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.REGISTRODataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource listadoBindingSource;
        private REGISTRODataSet REGISTRODataSet;
        private REGISTRODataSetTableAdapters.listadoTableAdapter listadoTableAdapter;
    }
}