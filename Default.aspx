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

        <div class="add-button">
            <a href="NovaPaginaCadastro.aspx" class="btn btn-success">Adicionar Novo Cliente</a>
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
                <asp:Repeater ID="rptClientes" runat="server" OnItemDataBound="FormatoDocumento">
                    <ItemTemplate>
                        <tr>
                            <td><%# Eval("ID") %></td>
                            <td><%# Eval("Nome") %></td>
                            <td><%# Eval("Tipo") %></td>
                            <td><asp:Label ID="lblNumeroDocumento" runat="server" Text='<%# Eval("NumeroDocumento") %>'></asp:Label></td>
                            <td><%# Eval("DataNascimento") %></td>
                            <td><%# Eval("DataCadastro") %></td>
                            <td class="action-buttons">
                                    <a href="UpdateCliente.aspx?id=<%# Eval("ID") %>" class="btn btn-primary btn-sm">Editar</a>
                                    <a href="ConfirmacaoExclusao.aspx?id=<%# Eval("ID") %>" class="btn btn-danger btn-sm">Excluir</a>
                                </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>

    </div> 
</asp:Content>
