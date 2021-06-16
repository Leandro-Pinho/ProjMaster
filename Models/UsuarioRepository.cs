using System.Collections.Generic;
using MySqlConnector;

namespace ProjMaster.Models
{
    public class UsuarioRepository
    {
        private const string _strConexao = "Database=pizzaria;Data Source=localhost;User Id=root;";
        public void Insert()
        {
            MySqlConnection conexao = new MySqlConnection(_strConexao);
            conexao.Open();
        }
        public void Insert(Usuario novoUsuario)
        {
            MySqlConnection conexao = new MySqlConnection(_strConexao);
            conexao.Open();
            string sql = "INSERT INTO usuario(nome, login, senha, dataNascimento) VALUES (@Nome, @Login, @Senha, @dataNascimento)";
            MySqlCommand comando = new MySqlCommand(sql, conexao);
            comando.Parameters.AddWithValue("@Nome", novoUsuario.Nome);
            comando.Parameters.AddWithValue("@Login", novoUsuario.Login);
            comando.Parameters.AddWithValue("@Senha", novoUsuario.Senha);
            comando.Parameters.AddWithValue("@dataNascimento", novoUsuario.DataNascimento);
            comando.ExecuteNonQuery();
            conexao.Close();
        } 
        public List<Usuario> Query()
        {
            MySqlConnection conexao = new MySqlConnection(_strConexao);
            conexao.Open();
            string sql = "SELECT * FROM Usuario ORDER BY nome";
            MySqlCommand comandoQuery = new MySqlCommand(sql, conexao);
            MySqlDataReader reader = comandoQuery.ExecuteReader();
            List<Usuario> lista = new List<Usuario>();
            while (reader.Read())
        {
            Usuario usr = new Usuario();
            usr.Id = reader.GetInt32("Id");
       
            if(!reader.IsDBNull(reader.GetOrdinal("Nome")))
                usr.Nome = reader.GetString("Nome");
       
            if(!reader.IsDBNull(reader.GetOrdinal("Login")))
                usr.Login = reader.GetString("Login");

            if(!reader.IsDBNull(reader.GetOrdinal("Senha")))
                usr.Senha = reader.GetString("Senha");

             if(!reader.IsDBNull(reader.GetOrdinal("dataNascimento")))
                usr.DataNascimento = reader.GetDateTime("dataNascimento");    
            lista.Add(usr);
        }
        conexao.Close();
        return lista;
        }   
        public Usuario QueryLogin(Usuario u)
        {
            MySqlConnection conexao = new MySqlConnection(_strConexao);
            conexao.Open();
            string sql = "SELECT * FROM Usuario WHERE login = @Login AND senha = @Senha";
            MySqlCommand comandoQuery = new MySqlCommand(sql, conexao);
            comandoQuery.Parameters.AddWithValue("@Login", u.Login);
            comandoQuery.Parameters.AddWithValue("@Senha", u.Senha);
            MySqlDataReader reader = comandoQuery.ExecuteReader();
            Usuario usr = null;
            if(reader.Read())
        {
            usr = new Usuario();
            usr.Id = reader.GetInt32("Id");
            if(!reader.IsDBNull(reader.GetOrdinal("Nome")))
                usr.Nome = reader.GetString("Nome");
       
            if(!reader.IsDBNull(reader.GetOrdinal("Login")))
                usr.Login = reader.GetString("Login");

            if(!reader.IsDBNull(reader.GetOrdinal("Senha")))
                usr.Senha = reader.GetString("Senha");
        }
   
        conexao.Close();
        return usr;
        }

    }
}