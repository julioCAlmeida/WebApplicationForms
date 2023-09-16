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
            string userEmail = txtEmail.Value;
            string userSenha = txtPassword.Value;
            bool rememberMe = checkRememberMe.Checked;

            if(ValidadeDasCredenciais(userEmail, userSenha))
			{
                FormsAuthentication.SetAuthCookie(userEmail, rememberMe);
                Response.Redirect("~/default.aspx");
            }
            else
			{
                lblErrorMessage.Text = "Credenciais inválidas. Por favor, tente novamente.";
                lblErrorMessage.Visible = true;
            }
        }
        private bool ValidadeDasCredenciais(string userEmail, string userPassword)
		{
            DAL.LoginDAL loginDAL = new DAL.LoginDAL();

            var user = loginDAL.Autenticar(userEmail, userPassword);

            if(user)
			{
                return true;
			}
            else
			{
                return false;
			}
		}
    }
}