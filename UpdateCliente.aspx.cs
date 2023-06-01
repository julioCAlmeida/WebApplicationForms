using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationForms
{
	public partial class UpdateCliente : System.Web.UI.Page
	{
		//BLL.Cliente cliente = new BLL.Cliente();
		protected void Page_Load(object sender, EventArgs e)
		{

			if (!IsPostBack)
			{
				if (!string.IsNullOrEmpty(Request.QueryString["id"]))
				{
					int id = Convert.ToInt32(Request.QueryString["id"]);

					DAL.ClienteDAL clienteDal = new DAL.ClienteDAL();
					BLL.Cliente cliente = clienteDal.ConsultarPorId(id);

					if (cliente != null)
					{
						txtNome.Value = cliente.Nome;
						ddlTipo.Value = cliente.Tipo;
						txtNumeroDocumento.Value = cliente.NumeroDocumento;
						txtDataNascimento.Value = cliente.DataNascimento.ToString("yyyy-MM-dd");

					}
					else
					{
						lblMessage.Text = "Cliente não encontrado.";
						Response.Redirect("Default.aspx");
					}
				}
				else
				{
					lblMessage.Text = "ID inválido.";
					Response.Redirect("Default.aspx");
				}
			}
		}
		protected void BtnAtualizar_Click(object sender, EventArgs e)
		{
			try
			{
				if (!string.IsNullOrEmpty(Request.QueryString["id"]))
				{
					int id = Convert.ToInt32(Request.QueryString["id"]);

					DAL.ClienteDAL clienteDAL = new DAL.ClienteDAL();
					BLL.Cliente cliente = clienteDAL.ConsultarPorId(id);

					if (cliente != null)
					{
						cliente.Nome = txtNome.Value;
						cliente.Tipo = ddlTipo.Value;
						cliente.NumeroDocumento = txtNumeroDocumento.Value;
						cliente.DataNascimento = DateTime.Parse(txtDataNascimento.Value);

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

						clienteDAL.Atualizar(cliente);

						Response.Redirect("Default.aspx");
					}
					else
					{
						lblMessage.Text = "Cliente não encontrado.";
						Response.Redirect("Default.aspx");
					}
				}
				else
				{
					lblMessage.Text = "ID inválido.";
					Response.Redirect("Default.aspx");
				}
			}
			catch (Exception ex)
			{
				lblMessage.Text = ex.Message;
			}
		}
	}
}