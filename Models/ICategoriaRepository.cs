using System.Collections.Generic;

namespace ProjMaster.Models
{
    public interface ICategoriaRepository
    {
        IEnumerable<Categoria> Categorias { get; }
    }
}