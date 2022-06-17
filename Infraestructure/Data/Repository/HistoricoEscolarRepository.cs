using Business.Interfaces;
using Business.Models;
using Infraestructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Data.Repository
{
    public class HistoricoEscolarRepository : Repository<HistoricoEscolar>, IHistoricoEscolarRepository
    {
        public HistoricoEscolarRepository(ApiContext context) : base(context)
        {

        }

        
    }
}
