using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace Ecommerce.Models
{
    public class CardapioModel
    {
        //static string conexao = "Server=ESN509VMYSQL;Database=burguer;User id=aluno;Password=Senai1234";
        static string conexao = "Server=localhost;Database=senai;User id=root;Password=yourf@ce281577";


        /*========================= CADASTRO DE PRODUTOS - LANCHES =========================*/
        public void Inserir_Produtos(Produtos produtos)
        {
            MySqlConnection con = new MySqlConnection(conexao);
            con.Open();
            string inserir = "INSERT INTO Produtos (nome_produto, descricao,valor, id_usuarios) VALUES (@nome_produto, @descricao,@valor,@usuario)";
            MySqlCommand comando = new MySqlCommand(inserir, con);
            comando.Parameters.AddWithValue("@nome_produto", produtos.nome_produto);
            comando.Parameters.AddWithValue("@descricao", produtos.descricao);
            comando.Parameters.AddWithValue("@valor", produtos.valor);
            comando.Parameters.AddWithValue("@usuario", produtos.usuario);
            comando.ExecuteNonQuery();
            con.Close();
        }



        /*========================= LISTAGEM DE PRODUTOS - LANCHES =========================*/
        public List<Produtos> Listar_Cardapio()
        {
            MySqlConnection con = new MySqlConnection(conexao);
            con.Open();
            string listarProduto = "SELECT * FROM Produtos ORDER BY nome_produto";
            MySqlCommand comando = new MySqlCommand(listarProduto, con);
            MySqlDataReader dados = comando.ExecuteReader();
            List<Produtos> lista = new List<Produtos>();
            while (dados.Read())
            {
                Produtos produtos = new Produtos();
                produtos.id = dados.GetInt32("id_produto");

                if (!dados.IsDBNull(dados.GetOrdinal("nome_produto")))
                    produtos.nome_produto = dados.GetString("nome_produto");

                if (!dados.IsDBNull(dados.GetOrdinal("descricao")))
                    produtos.descricao = dados.GetString("descricao");

                if (!dados.IsDBNull(dados.GetOrdinal("valor")))
                    produtos.valor = dados.GetDouble("valor");

                if (!dados.IsDBNull(dados.GetOrdinal("id_usuarios")))
                    produtos.usuario = dados.GetInt32("id_usuarios");

                lista.Add(produtos);
            }
            con.Close();
            return lista;
        }

        /*========================= ALTERAÇÃO DE PRODUTOS - LANCHES =========================*/
        public void Alterar_P(Produtos p)
        {
            MySqlConnection con = new MySqlConnection(conexao);
            con.Open();
            string alterar = "UPDATE Produtos SET nome_produto = @nome_produto, descricao = @descricao, valor = @valor  WHERE id_produto = @id";
            MySqlCommand comando = new MySqlCommand(alterar, con);
            comando.Parameters.AddWithValue("@id", p.id);
            comando.Parameters.AddWithValue("@nome_produto", p.nome_produto);
            comando.Parameters.AddWithValue("@descricao", p.descricao);
            comando.Parameters.AddWithValue("@valor", p.valor);
            comando.ExecuteNonQuery();
            con.Close();
        }

        /*========================= EXCLUSÃO DE PRODUTOS - LANCHES =========================*/
        public void Excluir_P(int id)
        {
            MySqlConnection con = new MySqlConnection(conexao);
            con.Open();
            string delete = "DELETE FROM Produtos WHERE id_produto = @id";
            MySqlCommand comando = new MySqlCommand(delete, con);
            comando.Parameters.AddWithValue("@id", id);
            comando.ExecuteNonQuery();
            con.Close();
        }

        /*========================= EXIBIÇÃO DE PRODUTOS - LANCHES =========================*/
        public Produtos ExibirProduto(int id)
        {
            int id_produto = id;
            MySqlConnection con = new MySqlConnection(conexao);
            con.Open();
            string consulta = "SELECT * FROM Produtos WHERE id_produto = @id";
            MySqlCommand comando = new MySqlCommand(consulta, con);
            comando.Parameters.AddWithValue("@id", id_produto);
            MySqlDataReader dados = comando.ExecuteReader();
            dados.Read();
            Produtos produtos = new Produtos();

            produtos.id = dados.GetInt32("id_produto");

            if (!dados.IsDBNull(dados.GetOrdinal("nome_produto")))
                produtos.nome_produto = dados.GetString("nome_produto");

            if (!dados.IsDBNull(dados.GetOrdinal("descricao")))
                produtos.descricao = dados.GetString("descricao");

            if (!dados.IsDBNull(dados.GetOrdinal("valor")))
                produtos.valor = dados.GetDouble("valor"); ;

            if (!dados.IsDBNull(dados.GetOrdinal("id_usuarios")))
                produtos.usuario = dados.GetInt32("id_usuarios");

            con.Close();
            return produtos;
        }
    }
}
