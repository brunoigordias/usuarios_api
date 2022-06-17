using Business.Interfaces;
using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class EscolaridadeService : IEscolaridadeService
    {
        private readonly IEscolaridadeRepository _escolaridadeRepository;

        public EscolaridadeService(IEscolaridadeRepository repository)
        {
            _escolaridadeRepository = repository;
        }
        public async Task<List<Escolaridade>> GetAll()
        {
            return await _escolaridadeRepository.GetAll();
        }

        public async Task<Escolaridade> GetById(int id)
        {
            return await _escolaridadeRepository.GetById(id);
        }
    }
}
