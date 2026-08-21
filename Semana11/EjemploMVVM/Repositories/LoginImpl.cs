using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace EjemploMVVM.Repositories
{
    class LoginImpl : ILogin
    {
        string cn;

        public LoginImpl()
        {
            cn = ConfigurationManager.ConnectionStrings["EjemploMVVM.Properties.Settings.NorthwindDB"].ConnectionString;
        }

        public bool ValidarUsuario(string username, string password)
        {
            string query = "select count(1) from [dbo].[Employees] WHERE LastName=@username AND Extension=@password";
            using(SqlConnection conex = new SqlConnection(cn))
            {
                conex.Open ();
                using (SqlCommand sqlCommand = new SqlCommand(query, conex))
                {
                    sqlCommand.Parameters.Add("@username", System.Data.SqlDbType.NVarChar, 40).Value = username;
                    sqlCommand.Parameters.Add("@password", System.Data.SqlDbType.NVarChar, 4).Value = password;

                    int cantidad = Convert.ToInt32(sqlCommand.ExecuteScalar());
                    return cantidad > 0;
                }
            }
        }
    }
}
