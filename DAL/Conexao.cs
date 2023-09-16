using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace DAL
{
	public class Conexao
	{
		SqlConnection con;

		public Conexao()
		{
			ConexaoSql();
		}

		public void ConexaoSql()
		{
			con = new SqlConnection();
			con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BancoDeDadosDevLean;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
		}
		public SqlConnection Conectar()
		{
			if (con.State == ConnectionState.Closed)
			{
				con.Open();
			}
			return con;
		}
		public void Desconectar()
		{
			if (con.State == ConnectionState.Open)
			{
				con.Close();
			}
		}
	}
}