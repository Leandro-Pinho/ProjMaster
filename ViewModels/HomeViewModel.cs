using System.Collections.Generic;
using ProjMaster.Models;

namespace ProjMaster.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Lanche> LanchesPreferidos { get; set; }
    }
}