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

    <asp:Button type="submit" ID="btnAtualizar" runat="server" class="btn btn-primary" OnClick="BtnAtualizar_Click" Text="Atualizar"></asp:Button>
    <asp:Label CssClass="error-message" ID="lblMessage" runat="server" Text=""></asp:Label>
</asp:Content>
