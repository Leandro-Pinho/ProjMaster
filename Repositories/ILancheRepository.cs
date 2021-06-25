using System.Collections.Generic;
using ProjMaster.Models;

namespace ProjMaster.Repositories
{
    public interface ILancheRepository
    {
        IEnumerable<Lanche> lanches { get; }
        Lanche GetMovieById(int Id);
    }
}