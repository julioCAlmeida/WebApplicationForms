<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplicationForms.Login" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">   
    <div class="container">
        <h1>Login</h1>
        <div class="form-group">
            <label for="txtEmail">E-mail:</label>
            <input type="text" id="txtEmail" runat="server" class="form-control" />
        </div>
        <div class="form-group">
            <label for="txtPassword">Senha:</label>
            <input type="password" id="txtPassword" runat="server" class="form-control" />
        </div>
        <div class="form-group">
            <asp:CheckBox ID="checkRememberMe" runat="server" Text="Remember Me" />
        </div>
        <div class="form-group">
            <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" class="btn btn-primary" />
        </div>
        <div class="form-group">
            <p class="text-start">Não tem uma conta? <a href="Registrar.aspx">Registre</a></p>
        </div>
        <div class="form-group">
            <asp:Label ID="lblErrorMessage" runat="server" Visible="false" ForeColor="Red"></asp:Label>
        </div>
    </div>
</asp:Content>  

