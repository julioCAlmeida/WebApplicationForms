<%@ Page Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NovaPaginaCadastro.aspx.cs" Inherits="WebApplicationForms.NovaPaginaCadastro" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
    .error-message {
        color: red;
    }
    /* Estilo para a tela de fundo desfocada */
    #overlay {
        position: fixed;
        top: 0;
        left: 0;
        width: 100%;
        height: 100%;
        background-color: rgba(0, 0, 0, 0.5); /* Cor de fundo com transparência para efeito de desfoque */
        backdrop-filter: blur(5px); /* Efeito de desfoque (recomendado usar em navegadores modernos) */
        z-index: 9998; /* Coloque o valor inferior ao z-index da mensagem flutuante */
    }

    /* Estilo para a mensagem flutuante */
    #mensagemFlutuante {
        position: fixed;
        top: 50%;
        left: 50%;
        transform: translate(-50%, -50%);
        background-color: white;
        color: green;
        font-size: 20px;
        border: none;
        border-radius: 5px;
        padding: 20px;
        z-index: 9999;
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

        <div class="form-group" style="display: flex; align-items: center; gap: 10px;">
            <a href="#" id="btnSalvar" runat="server" class="btn btn-success" onserverclick="btnSalvar_Click" style="text-decoration: none;">
                <i class="bi bi-plus-lg" style="margin-right: 3px;"></i>
                Cadastrar
            </a>
            <a href="Default.aspx" class="btn btn-primary">Voltar <i class="bi bi-backspace-reverse" style="margin-left: 3px;"></i></a>
        </div>

        <asp:Label CssClass="error-message" ID="lblMessage" runat="server" Text=""></asp:Label>
    </div>
    <script type="text/javascript">
        function exibirMensagemFlutuante(mensagem) {
            // Crie o contêiner da mensagem flutuante
            var divFlutuante = document.createElement("div");
            divFlutuante.id = "mensagemFlutuante";
            divFlutuante.innerHTML = "<p>" + mensagem + "</p>";

            // Adicione a div ao body
            document.body.appendChild(divFlutuante);

            // Crie o elemento de sobreposição com efeito de desfoque
            var overlay = document.createElement("div");
            overlay.id = "overlay";
            document.body.appendChild(overlay);

            // Após 3 segundos (2000 milissegundos), remova a mensagem flutuante e o elemento de sobreposição
            setTimeout(function () {
                document.body.removeChild(divFlutuante);
                document.body.removeChild(overlay);
                window.location.href = "Default.aspx";
            }, 2000);
        }
    </script>
</asp:Content>

