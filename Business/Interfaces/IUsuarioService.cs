using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IUsuarioService
    {
        public Task Create(Usuario usuario);
        public Task Update(Usuario usuario);
        public Task Delete(int usuarioId);
        public Task<Usuario> GetById(int id);
        public Task<List<Usuario>> GetAll();
    }
}
