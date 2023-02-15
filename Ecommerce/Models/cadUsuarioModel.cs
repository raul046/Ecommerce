using MySql.Data.MySqlClient;
using System;

namespace Ecommerce.Models
{
    public class cadUsuarioModel
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


        public string Inserir(Usuario User)
        {
            MySqlConnection con = new MySqlConnection(conexao);
            try
            {
                con.Open();
                MySqlCommand qry = new MySqlCommand("INSERT INTO Usuarios VALUES(@id, @nome_usuario, @sobrenome_usuario, @cpf, @email, @senha, @cep)", con);
                qry.Parameters.AddWithValue("@id", id);
                qry.Parameters.AddWithValue("@nome_usuario", nome_usuario);
                qry.Parameters.AddWithValue("@sobrenome_usuario", sobrenome_usuario);
                qry.Parameters.AddWithValue("@cpf", cpf);
                qry.Parameters.AddWithValue("@email", email);
                qry.Parameters.AddWithValue("@senha", senha);
                qry.Parameters.AddWithValue("@cep", cep);
                qry.ExecuteNonQuery();
                con.Close();

                return "Cadastrado com sucesso!";
            }
            catch (Exception ex)
            {
                return "ERRO: " + ex.Message;
            }
        }
    }

}
