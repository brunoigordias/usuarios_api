using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        
        [Required, StringLength(100)]
        public string Nome{ get; set; }
        
        [Required,StringLength(100)]
        public string Sobrenome { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }
        
        public int EscolaridadeId { get; set; }
        public Escolaridade Escolaridade { get; set; }

        public int HistoricoEscolarId { get; set; }
        public HistoricoEscolar HistoricoEscolar { get; set; }
    }
}
