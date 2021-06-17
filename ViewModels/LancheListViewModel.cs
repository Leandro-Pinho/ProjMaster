using System.Collections.Generic;
using ProjMaster.Models;

namespace ProjMaster.ViewModels
{
    public class LancheListViewModel
    {
        public IEnumerable<Lanche> Lanches { get; set; }
        public string CategoriaAtual { get; set; }
    }
}