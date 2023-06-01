using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Security;

namespace WebApplicationForms
{
	public partial class Login : System.Web.UI.Page
	{
        BLL.Login login = new BLL.Login();
        DAL.LoginDAL loginDal = new DAL.LoginDAL();
		protected void Page_Load(object sender, EventArgs e)
		{
            
		}
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            login.Email = txtEmail.Value;
            login.Senha = txtPassword.Value;

            if (loginDal.Autenticar(login))
			{
                Session.Add("UsuarioLogado", login.Email);
                Response.Redirect("~/default.aspx");
            }
            else
            {
                lblErrorMessage.Text = "Credenciais inválidas. Por favor, tente novamente.";
                lblErrorMessage.Visible = true;
            }
        }
    }
}