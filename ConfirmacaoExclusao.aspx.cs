using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplicationForms
{
    public partial class ConfirmacaoExclusao : System.Web.UI.Page
    {
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
                        litNomeCliente.Text = cliente.Nome;
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

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
           try
			{
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
				{
                    int id = Convert.ToInt32(Request.QueryString["id"]);

                    DAL.ClienteDAL clienteDAL = new DAL.ClienteDAL();
                    clienteDAL.Excluir(id);    

                    Response.Redirect("Default.aspx");
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

