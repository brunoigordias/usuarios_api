using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs
{
    public class UsuarioCreateDTO
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
