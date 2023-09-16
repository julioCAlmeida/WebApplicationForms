using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;

namespace WebApplicationForms
{
	public partial class NovaPaginaCadastro : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("Login.aspx");
            }
        }
        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            BLL.Cliente cliente = new BLL.Cliente();

            try
			{
                int usuarioID = ObterIDUsuarioAutenticado();

                cliente.Nome = txtNome.Text;
                cliente.Tipo = ddlTipo.SelectedValue;
                cliente.NumeroDocumento = txtNumeroDocumento.Text;
                cliente.DataNascimento = DateTime.Parse(txtDataNascimento.Text);
                cliente.DataCadastro = DateTime.Now;
                cliente.UsuarioID = usuarioID;

                if (string.IsNullOrEmpty(cliente.Nome) || string.IsNullOrEmpty(cliente.Tipo) ||
                    string.IsNullOrEmpty(cliente.NumeroDocumento) || cliente.DataNascimento == null)
                {
                    lblMessage.Text = "Todos os campos devem ser preenchidos.";
                    return;
                }

                if (cliente.Tipo == "CPF" && cliente.NumeroDocumento.Length != 11)
                {
                    lblMessage.Text = "Número do documento inválido para CPF.";

                    return;

                }
                else if (cliente.Tipo == "CNPJ" && cliente.NumeroDocumento.Length != 14)
                {

                    lblMessage.Text = "Número do documento inválido para CNPJ.";

                    return;
                    
                }

                DAL.ClienteDAL clienteDAL = new DAL.ClienteDAL();

                clienteDAL.Cadastrar(cliente);

                string mensagem = "Cliente cadastrado com sucesso!";
                ClientScript.RegisterStartupScript(this.GetType(), "ExibirMensagemScript",
                    "exibirMensagemFlutuante('" + mensagem + "');", true);
            }
            catch(Exception ex)
			{
                lblMessage.Text = ex.Message;
			}
        }
        public int ObterIDUsuarioAutenticado()
		{
            string emailUsuario = User.Identity.Name;

            DAL.UsuarioDAL usuarioDAL = new DAL.UsuarioDAL();

            int usuarioID = usuarioDAL.ConsultarIDPorNome(emailUsuario);

            return usuarioID;
		}
    }
}