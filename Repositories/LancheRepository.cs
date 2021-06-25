using System.Collections.Generic;
using System.Linq;
using ProjMaster.Data;
using ProjMaster.Models;
using Microsoft.EntityFrameworkCore;

namespace ProjMaster.Repositories
{
    public class LancheRepository : ILancheRepository
    {
        private readonly ProjMasterContext _context;
        public LancheRepository(ProjMasterContext contexto)
        {
            _context = contexto;
        }
        public IEnumerable<Lanche> lanches => _context.Lanche;

        public Lanche GetMovieById(int Id)
        {
            return _context.Lanche.FirstOrDefault(l => l.Id == Id);
        }
    }
}