using API.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace API.ViewModels
{
    [ModelBinder(typeof(JsonWithFilesFormDataModelBinder), Name = "usuario")]
    public class UsuarioCreateViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o Nome do Usuário"), StringLength(100)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o Sobrenome do Usuário"), StringLength(100)]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "Informe o e-mail do Usuário")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe a Data de Nascimento")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        public int EscolaridadeId { get; set; }

        public int HistoricoEscolarId { get; set; }

        public IFormFile HistoricoEscolar { get; set; }
    }
}
