<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConfirmacaoExclusao.aspx.cs" Inherits="WebApplicationForms.ConfirmacaoExclusao" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
    .error-message {
        color: red;
    }
    </style>
    <h1>Confirmação de Exclusão</h1>

    <p>Deseja realmente excluir o cliente: <strong><asp:Literal ID="litNomeCliente" runat="server"></asp:Literal></strong> ?</p>

    <div class="form-group" style="display: flex; align-items: center; gap: 10px;">
        <a href="#" id="btnExcluir" runat="server" class="btn btn-danger" onserverclick="btnExcluir_Click" style="text-decoration: none;">
            <i class="bi bi-trash" style="margin-right: 3px;"></i>
            Confirmar
        </a>
        <a href="Default.aspx" class="btn btn-primary">Cancelar<i class="bi bi-backspace-reverse" style="margin-left: 5px;"></i></a>
    </div>
    <asp:Label CssClass="error-message" ID="lblMessage" runat="server" Text=""></asp:Label>
</asp:Content>
