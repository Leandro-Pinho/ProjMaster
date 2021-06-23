using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace ProjMaster.Models
{
    public class LancheGeneroViewModel
    {
        public List<Lanche> Lanches { get; set; }
        public SelectList Generos { get; set; }
        public string LancheGenero { get; set; }
        public string SearchString { get; set; }
    }
}