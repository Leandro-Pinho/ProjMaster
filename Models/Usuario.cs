namespace ProjMaster.Models
{
    public class Usuario
    {
        public static int ADMIN = 1;
        public static int PADRAO = 0;

        public int Id { get; set; }
        public string Nome { get; set; }
        public string login { get; set; }
        public string senha { get; set; }
        public int tipo { get; set; }
    }
}