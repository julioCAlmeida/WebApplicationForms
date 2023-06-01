using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
	public class LoginDAL
	{
		Conexao con = new Conexao();
		public bool Autenticar(BLL.Login login)
		{
			SqlCommand cmd = new SqlCommand();
			cmd.Connection = con.Conectar();

			cmd.CommandText = @"SELECT Email, Senha 
								FROM Usuario
								WHERE Email = @email AND Senha = @senha";

			cmd.Parameters.AddWithValue("@email", login.Email);
			cmd.Parameters.AddWithValue("@senha", login.Senha);

			SqlDataReader dr = cmd.ExecuteReader();
			if (dr.HasRows)
			{
				con.Desconectar();
				return true;
			}
			else
			{
				con.Desconectar();
				return false;
			}
		}
	}
}
