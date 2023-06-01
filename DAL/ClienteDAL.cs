using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DAL
{
	public class ClienteDAL
	{
		Conexao con = new Conexao();
		SqlCommand cmd = new SqlCommand();

		public void Cadastrar(BLL.Cliente cliente)
		{
			cmd.Connection = con.Conectar();

			cmd.CommandText = @"INSERT INTO Clientes(
									Nome, 
									Tipo, 
									NumeroDocumento, 
									DataNascimento, 
									DataCadastro
									)
								VALUES	(@nome, @tipo, @numeroDocumento, 
										@dataNascimento, @dataCadastro)";

			cmd.Parameters.AddWithValue("@nome", cliente.Nome);
			cmd.Parameters.AddWithValue("@tipo", cliente.Tipo);
			cmd.Parameters.AddWithValue("@numeroDocumento", cliente.NumeroDocumento);
			cmd.Parameters.AddWithValue("@dataNascimento", cliente.DataNascimento);
			cmd.Parameters.AddWithValue("@dataCadastro", cliente.DataCadastro);
			//cmd.Parameters.AddWithValue("@usuarioID", cliente.UsuarioID);

			cmd.ExecuteNonQuery();
			con.Desconectar();
		}
		public List<BLL.Cliente> Consultar()
		{
			List<BLL.Cliente> clientes = new List<BLL.Cliente>();

			cmd.Connection = con.Conectar();
			cmd.CommandText = @"SELECT ID, Nome, Tipo, NumeroDocumento, DataNascimento, DataCadastro FROM Clientes";

			SqlDataReader reader = cmd.ExecuteReader();

			while (reader.Read())
			{
				int id = (int)reader["ID"];
				string nome = reader["Nome"].ToString();
				string tipo = reader["Tipo"].ToString();
				string numeroDocumento = reader["NumeroDocumento"].ToString();
				DateTime dataNascimento = (DateTime)reader["DataNascimento"];
				DateTime dataCadastro = (DateTime)reader["DataCadastro"];

				BLL.Cliente cliente = new BLL.Cliente
				{
					ID = id,
					Nome = nome,
					Tipo = tipo,
					NumeroDocumento = numeroDocumento,
					DataNascimento = dataNascimento,
					DataCadastro = dataCadastro
				};

				clientes.Add(cliente);
			}
			reader.Close();
			con.Desconectar();

			return clientes;
		}
		public BLL.Cliente ConsultarPorId(int id)
		{
			BLL.Cliente cliente = null;

			var connection = con.Conectar();
			string query = @"SELECT *
								FROM Clientes
								WHERE ID = @id";

			SqlCommand cmd = new SqlCommand(query, connection);

			cmd.Parameters.AddWithValue("@id", id);

			using (SqlDataReader reader = cmd.ExecuteReader())
			{
				if(reader.Read())
				{
					cliente = new BLL.Cliente();

					cliente.ID = (int)reader["ID"];
					cliente.Nome = reader["Nome"].ToString();
					cliente.Tipo = reader["Tipo"].ToString();
					cliente.NumeroDocumento = reader["NumeroDocumento"].ToString();
					cliente.DataNascimento = (DateTime)reader["DataNascimento"];

					reader.Close();

				}

			}
			con.Desconectar();

			return cliente;
		}
		public void Atualizar(BLL.Cliente cliente)
		{
			cmd.Connection = con.Conectar();
			cmd.CommandText = @"UPDATE Clientes 
								SET
									Nome = @nome,
									Tipo = @tipo,
									NumeroDocumento = @numeroDocumento,
									DataNascimento = @dataNascimento
								WHERE ID = @id";

			cmd.Parameters.AddWithValue("@nome", cliente.Nome);
			cmd.Parameters.AddWithValue("@tipo", cliente.Tipo);
			cmd.Parameters.AddWithValue("@numeroDocumento", cliente.NumeroDocumento);
			cmd.Parameters.AddWithValue("@dataNascimento", cliente.DataNascimento);
			cmd.Parameters.AddWithValue("@id", cliente.ID);

			cmd.ExecuteNonQuery();
			con.Desconectar();
		}
		public void Excluir(int id)
		{
			var connection = con.Conectar();
			string query = @"DELETE FROM Clientes WHERE ID = @id";

			using (SqlCommand cmd = new SqlCommand(query, connection))
			{
				cmd.Parameters.AddWithValue("@id", id);

				//connection.Open();
				cmd.ExecuteNonQuery();

			}


			con.Desconectar();
		}
	}
}
