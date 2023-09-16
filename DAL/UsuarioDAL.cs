using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
	public class UsuarioDAL
	{
		Conexao con = new Conexao();
		SqlCommand cmd = new SqlCommand();
		public void Cadastrar(BLL.Usuario usuario)
		{
			cmd.Connection = con.Conectar();

			cmd.CommandText = @"INSERT INTO Usuario(Nome, Email, Senha) VALUES(@nome, @email, @senha)";

			cmd.Parameters.Clear();

			cmd.Parameters.AddWithValue("@nome", usuario.Nome);
			cmd.Parameters.AddWithValue("@email", usuario.Email);
			cmd.Parameters.AddWithValue("@senha", usuario.Senha);

			cmd.ExecuteNonQuery();

			con.Desconectar();
		}
		public DataTable ConsultarTodos()
		{
			DataTable dt = new DataTable();

			cmd.Connection = con.Conectar();
			cmd.CommandText = @"SELECT * FROM Usuario";

			SqlDataAdapter da = new SqlDataAdapter();
			da.SelectCommand = cmd;
			da.Fill(dt);

			con.Desconectar();

			return dt;
		}
		public BLL.Usuario ConsultaPorEmail(string Email)
		{
			BLL.Usuario usuario = null;

			cmd.Connection = con.Conectar();
			cmd.CommandText = "SELECT * FROM Usuario WHERE Email = @email";

			cmd.Parameters.AddWithValue("@email", Email);

			SqlDataReader reader = cmd.ExecuteReader();

			if(reader.Read())
			{
				usuario = new BLL.Usuario();
				usuario.ID = Convert.ToInt32(reader["ID"]);
				usuario.Nome = reader["nome"].ToString();
				usuario.Email = reader["email"].ToString();
				usuario.Senha = reader["senha"].ToString();
			}
			reader.Close();
			con.Desconectar();

			return usuario;
		}
		public void Atualizar(BLL.Usuario usuario)
		{
			cmd.Connection = con.Conectar();

			cmd.CommandText = @"UPDATE Usuario 
								SET Nome = @nome, Email = @email, Senha = @senha 
								WHERE ID = @id";

			cmd.Parameters.AddWithValue("@nome", usuario.Nome);
			cmd.Parameters.AddWithValue("@email", usuario.Email);
			cmd.Parameters.AddWithValue("@senha", usuario.Senha);

			cmd.ExecuteNonQuery();

			con.Desconectar();
		}
		public void Excluir(int id)
		{
			cmd.Connection = con.Conectar();

			cmd.CommandText = @"DELETE FROM Usuario WHERE ID = @id";

			cmd.Parameters.AddWithValue("@id", id);

			cmd.ExecuteNonQuery();

			con.Desconectar();
		}
	}
}
