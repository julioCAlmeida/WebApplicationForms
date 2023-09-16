<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplicationForms._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<style>
    action-buttons {
            white-space: nowrap;
        }

    .add-button {
        text-align: right;
        margin-bottom: 10px;
    }
</style>
    <div class="container">
        <h1>Lista de Clientes</h1>

        <div class="add-button" style="display: flex; justify-content: end;">
            <a href="NovaPaginaCadastro.aspx" class="btn btn-success" style="display: flex; align-items: center; padding: 0 10px 0 0; border: none;">
                <i class="bi bi-plus" style="padding: 5px; font-size: 2rem;"></i>
                Adicionar Novo Cliente
            </a>
        </div>

        <table class="table table-striped">
            <thead class="thead-dark">
                <tr>
                    <th>ID</th>
                    <th>Nome</th>
                    <th>Tipo</th>
                    <th>Número do Documento</th>
                    <th>Data de Nascimento</th>
                    <th>Data do Cadastro</th>
                    <th>Ações</th>
                </tr>
            </thead>
            <tbody>
               <asp:Literal ID="ltlClientes" runat="server"></asp:Literal>
            </tbody>
        </table>
    </div> 
    <asp:Literal ID="ltlPaginacao" runat="server"></asp:Literal>
</asp:Content>
