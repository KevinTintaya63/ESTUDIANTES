using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ESTUDIANTES
{
    class Conexion
    {
        public static SqlConnection Conectar()
        {
            SqlConnection cn = new SqlConnection("server=DESKTOP-DE6Q868;database=REGISTRO;uid=sa;pwd=k.p_1.2.3");
            cn.Open();
            return cn;
        }

        public DataTable Buscar(string auxcodigo)
        {
            

            Conectar();
            string buscar = "SELECT * FROM ALUMNO WHERE CODIGO=@CODIGO";
            SqlCommand cmd = new SqlCommand(buscar, Conexion.Conectar());
            cmd.Parameters.AddWithValue("@CODIGO", auxcodigo);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }
        
        public Boolean Insertar(string auxcodigo,string auxprinom, string auxsegnom, string auxpriapell, string auxsegapell, string auxtel, int auxcel, string txtdirec, string auxemail, DateTime auxfechanac, string auxobser, int auxnota)
        {
            Conectar();
            string codigo = auxcodigo;
            int celular = auxcel;
            string correo = auxemail;

            // Validación de código
            string consultaCodigo = "SELECT COUNT(*) FROM ALUMNO WHERE CODIGO = @CODIGO";
            SqlCommand cmdCodigo = new SqlCommand(consultaCodigo, Conexion.Conectar());
            cmdCodigo.Parameters.AddWithValue("@CODIGO", codigo);

            int countCodigo = (int)cmdCodigo.ExecuteScalar();

            if (countCodigo > 0)
            {
                MessageBox.Show("El código ya existe en la base de datos");
                return false;
            }

            // Validación de celular
            string consultaCelular = "SELECT COUNT(*) FROM ALUMNO WHERE CELULAR = @CELULAR";
            SqlCommand cmdCelular = new SqlCommand(consultaCelular, Conexion.Conectar());
            cmdCelular.Parameters.AddWithValue("@CELULAR", celular);

            int countCelular = (int)cmdCelular.ExecuteScalar();

            if (countCelular > 0)
            {
                MessageBox.Show("El celular ya existe en la base de datos");
                return false;
            }

            // Validación de correo
            string consultaCorreo = "SELECT COUNT(*) FROM ALUMNO WHERE EMAIL = @EMAIL";
            SqlCommand cmdCorreo = new SqlCommand(consultaCorreo, Conexion.Conectar());
            cmdCorreo.Parameters.AddWithValue("@EMAIL", correo);

            int countCorreo = (int)cmdCorreo.ExecuteScalar();

            if (countCorreo > 0)
            {
                MessageBox.Show("El correo ya existe en la base de datos");
                return false;
            }
            
            string insertar = "INSERT INTO ALUMNO (CODIGO,PRIMER_NOMBRE,SEGUNDO_NOMBRE,PRIMER_APELLIDO,SEGUNDO_APELLIDO,TELEFONO,CELULAR,DIRECCION,EMAIL,FECHA_NACIMIENTO,OBSERVACIONES,NOTA)VALUES(@CODIGO,@PRIMER_NOMBRE,@SEGUNDO_NOMBRE,@PRIMER_APELLIDO,@SEGUNDO_APELLIDO,@TELEFONO,@CELULAR,@DIRECCION,@EMAIL,@FECHA_NACIMIENTO,@OBSERVACIONES,@NOTA)";
            SqlCommand cmd1 = new SqlCommand(insertar, Conectar());
            cmd1.Parameters.AddWithValue("@CODIGO", auxcodigo);
            cmd1.Parameters.AddWithValue("@PRIMER_NOMBRE", auxprinom);
            cmd1.Parameters.AddWithValue("@SEGUNDO_NOMBRE", auxsegnom);
            cmd1.Parameters.AddWithValue("@PRIMER_APELLIDO", auxpriapell);
            cmd1.Parameters.AddWithValue("@SEGUNDO_APELLIDO", auxsegapell);
            cmd1.Parameters.AddWithValue("@TELEFONO", auxtel);
            cmd1.Parameters.AddWithValue("@CELULAR", auxcel);
            cmd1.Parameters.AddWithValue("@DIRECCION", txtdirec);
            cmd1.Parameters.AddWithValue("@EMAIL", auxemail);
            cmd1.Parameters.AddWithValue("@FECHA_NACIMIENTO", auxfechanac);
            cmd1.Parameters.AddWithValue("@OBSERVACIONES", auxobser);
            cmd1.Parameters.AddWithValue("@NOTA", auxnota);

            cmd1.ExecuteNonQuery();
            return true;
        }

        public Boolean Actualizar(string auxcodigo, string auxprinom, string auxsegnom, string auxpriapell, string auxsegapell, string auxtel, int auxcel, string txtdirec, string auxemail, DateTime auxfechanac, string auxobser, int auxnota)
        {
            Conectar();

            string codigo = auxcodigo;
            int celular = auxcel;
            string correo = auxemail;

            // Validación de celular
            string consultaCelular = "SELECT COUNT(*) FROM ALUMNO WHERE CELULAR = @CELULAR AND CODIGO <> @CODIGO";
            SqlCommand cmdCelular = new SqlCommand(consultaCelular, Conexion.Conectar());
            cmdCelular.Parameters.AddWithValue("@CELULAR", celular);
            cmdCelular.Parameters.AddWithValue("@CODIGO", codigo);

            int countCelular = (int)cmdCelular.ExecuteScalar();

            if (countCelular > 0)
            {
                MessageBox.Show("El celular ya existe en la base de datos");
                return false;
            }

            // Validación de correo
            string consultaCorreo = "SELECT COUNT(*) FROM ALUMNO WHERE EMAIL = @EMAIL AND CODIGO <> @CODIGO";
            SqlCommand cmdCorreo = new SqlCommand(consultaCorreo, Conexion.Conectar());
            cmdCorreo.Parameters.AddWithValue("@EMAIL", correo);
            cmdCorreo.Parameters.AddWithValue("@CODIGO", codigo);

            int countCorreo = (int)cmdCorreo.ExecuteScalar();

            if (countCorreo > 0)
            {
                MessageBox.Show("El correo ya existe en la base de datos");
                return false;
            }


            string actualizar = "UPDATE ALUMNO SET CODIGO=@CODIGO,PRIMER_NOMBRE=@PRIMER_NOMBRE,SEGUNDO_NOMBRE=@SEGUNDO_NOMBRE,PRIMER_APELLIDO=@PRIMER_APELLIDO,SEGUNDO_APELLIDO=@SEGUNDO_APELLIDO,TELEFONO=@TELEFONO,CELULAR=@CELULAR,DIRECCION=@DIRECCION,EMAIL=@EMAIL,FECHA_NACIMIENTO=@FECHA_NACIMIENTO,OBSERVACIONES=@OBSERVACIONES, NOTA=@NOTA WHERE CODIGO=@CODIGO";
            SqlCommand cmd2 = new SqlCommand(actualizar, Conexion.Conectar());
            cmd2.Parameters.AddWithValue("@CODIGO", auxcodigo);
            cmd2.Parameters.AddWithValue("@PRIMER_NOMBRE", auxprinom);
            cmd2.Parameters.AddWithValue("@SEGUNDO_NOMBRE", auxsegnom);
            cmd2.Parameters.AddWithValue("@PRIMER_APELLIDO", auxpriapell);
            cmd2.Parameters.AddWithValue("@SEGUNDO_APELLIDO", auxsegapell);
            cmd2.Parameters.AddWithValue("@TELEFONO", auxtel);
            cmd2.Parameters.AddWithValue("@CELULAR", auxcel);
            cmd2.Parameters.AddWithValue("@DIRECCION", txtdirec);
            cmd2.Parameters.AddWithValue("@EMAIL", auxemail);
            cmd2.Parameters.AddWithValue("@FECHA_NACIMIENTO", auxfechanac);
            cmd2.Parameters.AddWithValue("@OBSERVACIONES", auxobser);
            cmd2.Parameters.AddWithValue("@NOTA", auxnota);

            cmd2.ExecuteNonQuery();

            return true;
        }
        public Boolean Eliminar(int auxcodigo)
        {
            Conectar();
            //SqlConnection con = new SqlConnection("server=DESKTOP-DE6Q868;database=REGISTRO;uid=sa;pwd=k.p_1.2.3");
            string eliminar = "DELETE FROM ALUMNO WHERE CODIGO=@CODIGO";
            SqlCommand cmd3 = new SqlCommand(eliminar, Conexion.Conectar());
            cmd3.Parameters.AddWithValue("@CODIGO", auxcodigo);

            cmd3.ExecuteNonQuery();

            return true;
        }
    }
}
