<%@ Page Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NovaPaginaCadastro.aspx.cs" Inherits="WebApplicationForms.NovaPaginaCadastro" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
    .error-message {
        color: red;
    }
</style>
    <div class="container">
       <h1>Cadastro de Cliente</h1>

       <div class="form-group">
            <label for="txtNome">Nome:</label>
            <asp:TextBox ID="txtNome" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="form-group">
            <label for="ddlTipo">Tipo:</label>
            <asp:DropDownList ID="ddlTipo" runat="server" CssClass="form-control">
                <asp:ListItem Text="CPF" Value="CPF"></asp:ListItem>
                <asp:ListItem Text="CNPJ" Value="CNPJ"></asp:ListItem>
            </asp:DropDownList>
        </div>

        <div class="form-group">
            <label for="txtNumeroDocumento">Número do Documento:</label>
            <asp:TextBox ID="txtNumeroDocumento" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="form-group">
            <label for="txtDataNascimento">Data de Nascimento:</label>
            <asp:TextBox ID="txtDataNascimento" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
        </div>

        <asp:Button ID="btnSalvar" runat="server" Text="Salvar" CssClass="btn btn-primary" OnClick="btnSalvar_Click" />
        <asp:Label CssClass="error-message" ID="lblMessage" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>

