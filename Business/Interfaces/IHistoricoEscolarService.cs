using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IHistoricoEscolarService
    {
        public Task<HistoricoEscolar> GetById(int id);
        public Task<List<HistoricoEscolar>> GetAll();
    }
}
