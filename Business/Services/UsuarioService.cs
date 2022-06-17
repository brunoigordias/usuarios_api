using Business.Interfaces;
using Business.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository repository)
        {
            _usuarioRepository = repository;
        }
        public async Task Create(Usuario usuario)
        {
            var user = _usuarioRepository.Search(u => 
                    u.Nome == usuario.Nome && u.Sobrenome == usuario.Sobrenome
                    && u.DataNascimento == usuario.DataNascimento);

            if (user == null)
            {
                throw new DuplicateWaitObjectException("Já existe um usuário com os dados informados");
            }

            await _usuarioRepository.Create(usuario);
        }

        public async Task Delete(int usuarioId)
        {
            var usuario = await _usuarioRepository.GetById(usuarioId);

            if (usuario == null)
                return;

            await _usuarioRepository.Delete(usuario);
        }

        public async Task<List<Usuario>> GetAll()
        {
            return await _usuarioRepository.GetAll();
        }

        public async Task<Usuario> GetById(int id)
        {
            return await _usuarioRepository.GetById(id);
        }

        public Task Update(Usuario usuario)
        {

            var user = _usuarioRepository.Search(u => u.Id != usuario.Id &&
                   u.Nome == usuario.Nome && u.Sobrenome == usuario.Sobrenome
                   && u.DataNascimento == usuario.DataNascimento);

            if (user == null)
            {
                throw new DuplicateWaitObjectException("Já existe um usuário com os dados informados");
            }

            return _usuarioRepository.Update(usuario);
        }



    }
}
