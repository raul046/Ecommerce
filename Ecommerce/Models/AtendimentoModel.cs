using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
namespace Ecommerce.Models
{
    public class AtendimentoModel
    {
        //static string conexao = "Server=ESN509VMYSQL;Database=burguer;User id=aluno;Password=Senai1234";
        static string conexao = "Server=localhost;Database=senai;User id=root;Password=yourf@ce281577";

        public int id { get; set; }
        public string nome_usuario { get; set; }
        public string sobrenome_usuario { get; set; }
        public string email { get; set; }
        public string mensagem { get; set; }

        /*========================= MENSAGEM USUÁRIO PARA ADMIN =========================*/
        public void Enviar_Atendimento(AtendimentoModel a)
        {
            MySqlConnection con = new MySqlConnection(conexao);
            con.Open();
            string inserir = "INSERT INTO Atendimento (nome_usuario,sobrenome_usuario,email,mensagem) VALUES (@nome_usuario,@sobrenome_usuario, @email, @mensagem)";
            MySqlCommand comando = new MySqlCommand(inserir, con);
            comando.Parameters.AddWithValue("@nome_usuario", a.nome_usuario);
            comando.Parameters.AddWithValue("@sobrenome_usuario", a.sobrenome_usuario);
            comando.Parameters.AddWithValue("@email", a.email);
            comando.Parameters.AddWithValue("@mensagem", a.mensagem);
            comando.ExecuteNonQuery();
            con.Close();

        }

    }
}