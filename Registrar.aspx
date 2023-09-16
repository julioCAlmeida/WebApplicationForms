<%@ Page Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registrar.aspx.cs" Inherits="WebApplicationForms.Registrar" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
    .error-message {
        color: red;
    }
</style>
<div class="container">
        <h1>Crie uma conta</h1>
        <div class="form-group">
            <label for="txtNome">Nome:</label>
            <input type="text" id="txtNome" runat="server" class="form-control" />
        </div>
        <div class="form-group">
            <label for="txtEmail">E-mail:</label>
            <input type="text" id="txtEmail" runat="server" class="form-control" />
        </div>
        <div class="form-group">
            <label for="txtSenha">Senha:</label>
            <input type="password" id="txtSenha" runat="server" class="form-control" />
        </div>
        <div class="form-group">
            <asp:Button ID="btnRegistrar" runat="server" Text="Cadastrar" OnClick="btnRegistrar_Click" class="btn btn-primary" /> 
        </div>
        <div class="form-group">
            <p class="text-start">Já tem cadastro? <a href="Login.aspx">Login</a></p>
        </div>
         <asp:Label CssClass="error-message" ID="lblMessage" runat="server" Text=""></asp:Label>
    </div>
</asp:Content> 
