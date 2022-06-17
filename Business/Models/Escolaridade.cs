using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public class Escolaridade
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe a Descrição da Escolaridade"), StringLength(100)]
        public string Descricao { get; set; }

        public IEnumerable<Usuario> Usuarios { get; set; }
    }
}
