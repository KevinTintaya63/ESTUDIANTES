using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESTUDIANTES
{
    class basedatos
    {
        public Boolean Conectarbd(string auxusu, string auxpas)
        {
            Boolean respuesta;
            SqlConnection con = new SqlConnection("server=DESKTOP-DE6Q868;database=REGISTRO;uid=sa;pwd=k.p_1.2.3");
            SqlCommand sql = con.CreateCommand();
            sql.CommandText = "SELECT * FROM TBUSUARIO " +
                "WHERE USUARIO='" + auxusu + "' AND PASSWORD='" + auxpas + "'";
            con.Open();
            SqlDataReader sqldr = sql.ExecuteReader();
            if (sqldr.Read())
                respuesta = true;
            else
                respuesta = false;
            sqldr.Close();
            con.Close();
            return respuesta;
        }
    }
}
