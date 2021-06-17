using System.Collections.Generic;

namespace ProjMaster.Models
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly BibliotecaContext _context;
        public CategoriaRepository(BibliotecaContext contexto)
        {
            _context = contexto;
        }
        public IEnumerable<Categoria> Categorias => _context.Categorias;
    }
}