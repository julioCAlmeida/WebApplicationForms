<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UpdateCliente.aspx.cs" Inherits="WebApplicationForms.UpdateCliente" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     <style>
    .error-message {
        color: red;
    }
</style>
    <h1>Atualizar Cliente</h1>

    <div class="form-group">
        <label for="txtNome">Nome:</label>
        <input type="text" ID="txtNome" runat="server" class="form-control" />
    </div>

    <div class="form-group">
        <label for="ddlTipo">Tipo:</label>
        <select ID="ddlTipo" runat="server" class="form-control">
            <option value="CPF">CPF</option>
            <option value="CNPJ">CNPJ</option>
        </select>
    </div>
    <div class="form-group">
        <label for="txtNumeroDocumento">Número do Documento:</label>
        <input type="text" ID="txtNumeroDocumento" runat="server" class="form-control" />
    </div>

    <div class="form-group">
        <label for="txtDataNascimento">Data de Nascimento:</label>
        <input type="date" ID="txtDataNascimento"  runat="server" class="form-control" />
    </div>

    <div class="form-group" style="display: flex; align-items: center; gap: 10px;">
        <a href="#" id="btnAtualizar" runat="server" class="btn btn-success" onserverclick="BtnAtualizar_Click" style="text-decoration: none;">
            <i class="bi bi-arrow-clockwise" style="margin-right: 3px;"></i>
            Atualizar
        </a>
        <a href="Default.aspx" class="btn btn-primary">Cancelar <i class="bi bi-backspace-reverse" style="margin-left: 3px;"></i></a>
    </div>
    <asp:Label CssClass="error-message" ID="lblMessage" runat="server" Text=""></asp:Label>
</asp:Content>
