using System;

namespace BLL
{
	public class Cliente
	{
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public string NumeroDocumento { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataCadastro { get; set; }
        //public int UsuarioID { get; set; }
    }
}
