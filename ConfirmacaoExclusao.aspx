<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConfirmacaoExclusao.aspx.cs" Inherits="WebApplicationForms.ConfirmacaoExclusao" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
    .error-message {
        color: red;
    }
    </style>
    <h1>Confirmação de Exclusão</h1>

    <p>Deseja realmente excluir o cliente: <span><asp:Literal ID="litNomeCliente" runat="server"></asp:Literal> ?</span></p>

    <div class="form-group">
        <asp:Button type="submit" class="btn btn-danger" ID="btnExcluir" runat="server" OnClick="btnExcluir_Click" Text="Confirmar"></asp:Button>
        <a href="Default.aspx" class="btn btn-primary">Cancelar</a>
    </div>
    <asp:Label CssClass="error-message" ID="lblMessage" runat="server" Text=""></asp:Label>
</asp:Content>
