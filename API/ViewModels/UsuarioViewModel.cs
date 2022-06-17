namespace API.ViewModels
{
    public class UsuarioViewModel
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public string Email { get; set; }

        public DateTime DataNascimento { get; set; }

        public int EscolaridadeId { get; set; }
        public string Escolaridade { get; set; }

        public int HistoricoEscolarId { get; set; }
        public string HistoricoEscolar { get; set; }
    }
}
