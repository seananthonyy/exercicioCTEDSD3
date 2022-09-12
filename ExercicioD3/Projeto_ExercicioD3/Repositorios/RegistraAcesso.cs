using Projeto_ExercicioD3.Models;
using System.Data.SqlClient;

namespace Projeto_ExercicioD3.Repositorios
{
    internal class RegistraAcesso : Usuario
    {
        public void Registrar(Usuario novoUsuario)
        {
            string stringConexao = "Server=labsoft.pcs.usp.br; Initial Catalog=db_1; User id=usuario_1; pwd=38929610854;";

            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                string queryInsert = "INSERT INTO ListaUsuarios (Id, Nome, Email, Senha) VALUES (@Id, @Nome, @Email, @Senha)";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@Id", novoUsuario.Id);
                    cmd.Parameters.AddWithValue("@Nome", novoUsuario.Nome);
                    cmd.Parameters.AddWithValue("@Email", novoUsuario.Email);
                    cmd.Parameters.AddWithValue("@Senha", novoUsuario.Senha);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
