using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace WebApplicationForms
{
	public partial class Registrar : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			
		}
		protected void btnRegistrar_Click(object sender, EventArgs e)
		{
			BLL.Usuario usuario = new BLL.Usuario();
			DAL.UsuarioDAL usuarioDAL = new DAL.UsuarioDAL();

			usuario.Nome = txtNome.Value;
			usuario.Email = txtEmail.Value;
			usuario.Senha = txtSenha.Value;

			var checkUsuario = usuarioDAL.ConsultaPorEmail(usuario.Email);

			if(string.IsNullOrEmpty(usuario.Nome) || string.IsNullOrEmpty(usuario.Email) ||
					string.IsNullOrEmpty(usuario.Senha))
			{
				lblMessage.Text = "Todos os campos devem ser preenchidos.";
				return;
			}

			if(checkUsuario != null)
			{
				lblMessage.Text = "E-mail já cadastrado. Por favor, escolha outro e-mail.";
				return;
			}


			usuarioDAL.Cadastrar(usuario);

			Response.Redirect("Login.aspx");
		}
		
	}
}