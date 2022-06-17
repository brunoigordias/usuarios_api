using Business.Interfaces;
using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class HistoricoEscolarService : IHistoricoEscolarService
    {
        private readonly IHistoricoEscolarRepository _escolaridadeRepository;

        public HistoricoEscolarService(IHistoricoEscolarRepository repository)
        {
            _escolaridadeRepository = repository;
        }

        public async Task<List<HistoricoEscolar>> GetAll()
        {
            return await _escolaridadeRepository.GetAll();
        }

        public async Task<HistoricoEscolar> GetById(int id)
        {
            return await _escolaridadeRepository.GetById(id);
        }

    }
}
