using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace WebApplicationForms
{
	public partial class _Default : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!User.Identity.IsAuthenticated)
			{
				Response.Redirect("Login.aspx");
			}

			if (!IsPostBack)
			{
				DAL.ClienteDAL todosClientes = new DAL.ClienteDAL();

				var countClientes = todosClientes.Consultar();

				int itensPorPagina = 10;

				// Obtenha o número da página atual da query string ou defina o valor padrão como 1
				int numeroPagina = 1;
				if (!string.IsNullOrEmpty(Request.QueryString["page"]))
				{
					int.TryParse(Request.QueryString["page"], out numeroPagina);
				}

				// Realize a paginação manualmente
				var clientesPaginados = PaginarLista(countClientes, numeroPagina, itensPorPagina);

				string tableRows = string.Empty;
				foreach (var cliente in clientesPaginados)
				{
					string numeroDocumento = cliente.Tipo == "CPF" ? FormatCPF(cliente.NumeroDocumento) : FormatCNPJ(cliente.NumeroDocumento);

					string row = $@"
						<tr>
							<td>{cliente.ID}</td>
							<td>{cliente.Nome}</td>
							<td>{cliente.Tipo}</td>
							<td>{numeroDocumento}</td>
							<td>{cliente.DataNascimento.ToString("dd/MM/yyyy")}</td>
							<td>{cliente.DataCadastro.ToString()}</td>
							<td>
								<a href='UpdateCliente.aspx?id={cliente.ID}' class='btn btn-primary btn-sm'><i class='bi bi-arrow-clockwise' style='margin-right: 3px;'></i>Editar</a>
								<a href='ConfirmacaoExclusao.aspx?id={cliente.ID}' class='btn btn-danger btn-sm'><i class='bi bi-trash' style='margin-right: 3px;'></i>Excluir</a>
							</td>
						</tr>";

					tableRows += row;
				}

				ltlClientes.Text = tableRows;

				// Adicione os links de navegação
				AdicionarLinksDeNavegacao(numeroPagina, todosClientes.Consultar().Count(), itensPorPagina);
			}
		}

		private void AdicionarLinksDeNavegacao(int paginaAtual, int numeroTotalDeClientes, int itensPorPagina)
		{
			int numeroTotalPaginas = (int)Math.Ceiling((double)numeroTotalDeClientes / itensPorPagina);

			string linksPaginacao = string.Empty;

			if (numeroTotalPaginas > 1)
			{
				linksPaginacao += $@"<li class='page-item {(paginaAtual == 1 ? "disabled" : "")}'>
                               <a class='page-link' href='?page={paginaAtual - 1}' aria-label='Previous'>
                                 <span aria-hidden='true'>&laquo;</span>
                               </a>
                             </li>";

				for (int pagina = 1; pagina <= numeroTotalPaginas; pagina++)
				{
					linksPaginacao += $@"<li class='page-item {(pagina == paginaAtual ? "active" : "")}'>
                                   <a class='page-link' href='?page={pagina}'>{pagina}</a>
                                 </li>";
				}

				linksPaginacao += $@"<li class='page-item {(paginaAtual == numeroTotalPaginas ? "disabled" : "")}'>
                               <a class='page-link' href='?page={paginaAtual + 1}' aria-label='Next'>
                                 <span aria-hidden='true'>&raquo;</span>
                               </a>
                             </li>";
			}
			string htmlPaginacao = $@"
				<nav aria-label='Page navigation example'>
					<ul class='pagination'>
						{linksPaginacao}
					</ul>
				</nav>";

			ltlPaginacao.Text = htmlPaginacao;
		}
		protected List<BLL.Cliente> PaginarLista(List<BLL.Cliente> lista, int numeroPagina, int itensPorPagina)
		{
			// Calcule o índice inicial e final dos itens na página atual
			int indiceInicial = (numeroPagina - 1) * itensPorPagina;
			int indiceFinal = Math.Min(indiceInicial + itensPorPagina, lista.Count);

			// Retorne os itens da página atual
			return lista.GetRange(indiceInicial, indiceFinal - indiceInicial);
		}

		protected void FormatoDocumento(object sender, RepeaterItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				BLL.Cliente cliente = (BLL.Cliente)e.Item.DataItem;
				Label lblNumeroDocumento = (Label)e.Item.FindControl("lblNumeroDocumento");

				if (cliente.Tipo == "CPF")
				{
					lblNumeroDocumento.Text = FormatCPF(cliente.NumeroDocumento);
				}
				else if (cliente.Tipo == "CNPJ")
				{
					lblNumeroDocumento.Text = FormatCNPJ(cliente.NumeroDocumento);
				}
			}
		}
		private string FormatCPF(string cpf)
		{
			// Aplicar máscara de CPF: XXX.XXX.XXX-XX
			return cpf.Insert(3, ".").Insert(7, ".").Insert(11, "-");
		}

		private string FormatCNPJ(string cnpj)
		{
			// Aplicar máscara de CNPJ: XX.XXX.XXX/XXXX-XX
			return cnpj.Insert(2, ".").Insert(6, ".").Insert(10, "/").Insert(15, "-");
		}
	}
}