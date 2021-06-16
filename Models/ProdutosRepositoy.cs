using MySqlConnector;
using System.Collections.Generic;

namespace ProjMaster.Models
{
    public class ProdutosRepository 
    {
        private const string _strConexao = "Database=pizzaria;Data Source=localhost;User Id=root;";
        public void Cadastra(Produtos m)
        {
            MySqlConnection conexao = new MySqlConnection(_strConexao);
            conexao.Open();

            string sql = "INSERT INTO Produtos (nome, descricao, valor, quantidade) VALUES (@nome, @descricao, @valor, @quantidade)";

            MySqlCommand comando = new MySqlCommand(sql, conexao);
            comando.Parameters.AddWithValue("@nome", m.Nome);
            comando.Parameters.AddWithValue("@descricao", m.Descricao);
            comando.Parameters.AddWithValue("@valor", m.Valor);
            comando.Parameters.AddWithValue("@quantidade", m.Quantidade);
  
            comando.ExecuteNonQuery();
            conexao.Close();
        }
        public List<Produtos> Lista(int id)
        {  
            MySqlConnection conexao = new MySqlConnection(_strConexao);
            conexao.Open();

            string sql = "SELECT * FROM Produtos " + (id > 0 ? "WHWRE id = @Id" : "") + " ORDER BY nome";
            MySqlCommand ComandoQuery = new MySqlCommand(sql, conexao);
            if(id > 0){
                ComandoQuery.Parameters.AddWithValue("@Id", id);
            }

            MySqlDataReader Reader = ComandoQuery.ExecuteReader();

            List<Produtos> lista = new List<Produtos>();

            while (Reader.Read())
            {
                Produtos produto = new Produtos();
                produto.Id = Reader.GetInt32("Id");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Nome")))
                    produto.Nome = Reader.GetString("Nome");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Descricao")))
                    produto.Descricao = Reader.GetString("Descricao");  

                if (!Reader.IsDBNull(Reader.GetOrdinal("Valor")))
                    produto.Valor = Reader.GetDouble("Valor");  

                if (!Reader.IsDBNull(Reader.GetOrdinal("Quantidade")))
                    produto.Quantidade = Reader.GetInt32("Quantidade");      
             
                lista.Add(produto);      
            }

            conexao.Close();
            return lista;
        }
        public List<Produtos> Lista()
        {
            return Lista(0);
        }
    }
}