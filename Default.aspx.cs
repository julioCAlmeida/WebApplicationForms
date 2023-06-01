using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace WebApplicationForms
{
	public partial class _Default : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{

				DAL.ClienteDAL clientes = new DAL.ClienteDAL();

				rptClientes.DataSource = clientes.Consultar();
				rptClientes.DataBind();
			}
		}
		protected void FormatoDocumento(object sender, RepeaterItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				BLL.Cliente cliente = (BLL.Cliente)e.Item.DataItem;
				Label lblNumeroDocumento = (Label)e.Item.FindControl("lblNumeroDocumento");

				if (cliente.Tipo == "CPF")
				{
					lblNumeroDocumento.Text = FormatCPF(cliente.NumeroDocumento);
				}
				else if (cliente.Tipo == "CNPJ")
				{
					lblNumeroDocumento.Text = FormatCNPJ(cliente.NumeroDocumento);
				}
			}
		}
		private string FormatCPF(string cpf)
		{
			// Aplicar máscara de CPF: XXX.XXX.XXX-XX
			return cpf.Insert(3, ".").Insert(7, ".").Insert(11, "-");
		}

		private string FormatCNPJ(string cnpj)
		{
			// Aplicar máscara de CNPJ: XX.XXX.XXX/XXXX-XX
			return cnpj.Insert(2, ".").Insert(6, ".").Insert(10, "/").Insert(15, "-");
		}
	}
}