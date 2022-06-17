using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public class HistoricoEscolar
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o Formato"), StringLength(20)]
        public string Formato { get; set; }

        [Required(ErrorMessage = "Informe o Nome do Historico"), StringLength(100)]
        public string Nome { get; set; }

        public IEnumerable<Usuario> Usuarios { get; set; }
    }
}
