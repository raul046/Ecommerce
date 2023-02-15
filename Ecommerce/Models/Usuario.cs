using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace Ecommerce.Models
{
    public class Usuario
    {
        //static string conexao = "Server=ESN509VMYSQL;Database=burguer;User id=aluno;Password=Senai1234";
        static string conexao = "Server=localhost;Database=senai;User id=root;Password=yourf@ce281577";
        public int id { get; set; }
        public string nome_usuario { get; set; }
        public string sobrenome_usuario { get; set; }
        public string cpf { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public string cep { get; set; }
        public string conta { get; set; }

        /*========================= CADASTRAR =========================*/
        public void Inserir(Usuario user)
        {
            MySqlConnection con = new MySqlConnection(conexao);
            con.Open();
            string inserir = "INSERT INTO Usuarios (nome_usuario,sobrenome_usuario,cpf,email,senha,cep) VALUES (@nome_usuario, @sobrenome_usuario, @cpf, @email, @senha, @cep)";
            MySqlCommand comando = new MySqlCommand(inserir, con);
            comando.Parameters.AddWithValue("@nome_usuario", user.nome_usuario);
            comando.Parameters.AddWithValue("@sobrenome_usuario", user.sobrenome_usuario);
            comando.Parameters.AddWithValue("@cpf", user.cpf);
            comando.Parameters.AddWithValue("@email", user.email);
            comando.Parameters.AddWithValue("@senha", user.senha);
            comando.Parameters.AddWithValue("@cep", user.cep);
            comando.ExecuteNonQuery();
            con.Close();
        }

        /*========================= LOGIN =========================*/
        public Usuario Login(Usuario user)
        {
            MySqlConnection con = new MySqlConnection(conexao);
            con.Open();
            string myLogin = "SELECT * FROM Usuarios WHERE email = @email AND senha = @senha";
            MySqlCommand comando = new MySqlCommand(myLogin, con);
            comando.Parameters.AddWithValue("@email", user.email);
            comando.Parameters.AddWithValue("@senha", user.senha);
            MySqlDataReader dados = comando.ExecuteReader();
            Usuario us = null;
            if (dados.Read())
            {
                us = new Usuario();
                us.id = dados.GetInt32("id_usuarios");

                if (!dados.IsDBNull(dados.GetOrdinal("email")))
                    us.email = dados.GetString("email");

                if (!dados.IsDBNull(dados.GetOrdinal("senha")))
                    us.email = dados.GetString("senha");

                if (!dados.IsDBNull(dados.GetOrdinal("nome_usuario")))
                    us.nome_usuario = dados.GetString("nome_usuario");

                if (!dados.IsDBNull(dados.GetOrdinal("conta")))
                    us.conta = dados.GetString("conta");
            }
            con.Close();
            return us;
        }

        /*========================= LISTAR USUÁRIOS - ADMIN =========================*/
        public List<Usuario> Listar_Usuarios()
        {
            MySqlConnection con = new MySqlConnection(conexao);
            con.Open();
            string list = "SELECT * FROM Usuarios ORDER BY nome_usuario";
            MySqlCommand comando = new MySqlCommand(list, con);
            MySqlDataReader dados = comando.ExecuteReader();
            List<Usuario> lista = new List<Usuario>();
            while (dados.Read())
            {
                Usuario usuario = new Usuario();

                usuario.id = dados.GetInt32("id_usuarios");

                if (!dados.IsDBNull(dados.GetOrdinal("nome_usuario")))
                    usuario.nome_usuario = dados.GetString("nome_usuario");


                if (!dados.IsDBNull(dados.GetOrdinal("sobrenome_usuario")))
                    usuario.sobrenome_usuario = dados.GetString("sobrenome_usuario");


                if (!dados.IsDBNull(dados.GetOrdinal("cpf")))
                    usuario.cpf = dados.GetString("cpf");


                if (!dados.IsDBNull(dados.GetOrdinal("email")))
                    usuario.email = dados.GetString("email");


                if (!dados.IsDBNull(dados.GetOrdinal("senha")))
                    usuario.senha = dados.GetString("senha");


                if (!dados.IsDBNull(dados.GetOrdinal("cep")))
                    usuario.cep = dados.GetString("cep");

                lista.Add(usuario);
            }
            con.Close();
            return lista;
        }

        /*========================= RETORNO - EXIBIR USUÁRIOS =========================*/
        public Usuario ExibirUsuario(int id)
        {
            int id_user = id;
            MySqlConnection con = new MySqlConnection(conexao);
            con.Open();
            string consulta = "SELECT * FROM Usuarios WHERE id_usuarios = @id";
            MySqlCommand comando = new MySqlCommand(consulta, con);
            comando.Parameters.AddWithValue("@id", id_user);
            MySqlDataReader dados = comando.ExecuteReader();

            Usuario usuario = new Usuario();
            if (dados.HasRows)
            {
                while (dados.Read())
                {

                    usuario.id = dados.GetInt32("id_usuarios");

                    if (!dados.IsDBNull(dados.GetOrdinal("nome_usuario"))) 
                        usuario.nome_usuario = dados.GetString("nome_usuario");


                    if (!dados.IsDBNull(dados.GetOrdinal("sobrenome_usuario")))
                        usuario.sobrenome_usuario = dados.GetString("sobrenome_usuario");


                    if (!dados.IsDBNull(dados.GetOrdinal("cpf")))
                        usuario.cpf = dados.GetString("cpf");


                    if (!dados.IsDBNull(dados.GetOrdinal("email")))
                        usuario.email = dados.GetString("email");


                    if (!dados.IsDBNull(dados.GetOrdinal("senha"))) 
                        usuario.senha = dados.GetString("senha");


                    if (!dados.IsDBNull(dados.GetOrdinal("cep")))
                        usuario.cep = dados.GetString("cep");
                }
            }
            con.Close();
            return usuario;
        }

        /*========================= ALTERAR USUÁRIOS - ADMIN =========================*/
        public void Alterar(Usuario user)
        {
            MySqlConnection con = new MySqlConnection(conexao);
            con.Open();
            string alterar = "UPDATE Usuarios SET nome_usuario = @nome_usuario, sobrenome_usuario = @sobrenome_usuario, cpf = @cpf, email = @email, senha = @senha, cep = @cep WHERE id_usuarios = @id";
            MySqlCommand comando = new MySqlCommand(alterar, con);

            comando.Parameters.AddWithValue("@id", user.id);
            comando.Parameters.AddWithValue("@nome_usuario", user.nome_usuario);
            comando.Parameters.AddWithValue("@sobrenome_usuario", user.sobrenome_usuario);
            comando.Parameters.AddWithValue("@cpf", user.cpf);
            comando.Parameters.AddWithValue("@email", user.email);
            comando.Parameters.AddWithValue("@senha", user.senha);
            comando.Parameters.AddWithValue("@cep", user.cep);
            comando.ExecuteNonQuery();
            con.Close();
        }

        /*========================= EXLUIR USUÁRIOS - ADMIN =========================*/
        public void Excluir(int id)
        {
            MySqlConnection con = new MySqlConnection(conexao);
            con.Open();
            string delete = "DELETE FROM Usuarios WHERE id_usuarios = @id";
            MySqlCommand comando = new MySqlCommand(delete, con);
            comando.Parameters.AddWithValue("@id", id);
            comando.ExecuteNonQuery();
            con.Close();
        }
      
    }
}
