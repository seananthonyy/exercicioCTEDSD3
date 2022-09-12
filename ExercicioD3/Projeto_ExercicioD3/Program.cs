using Projeto_ExercicioD3.Repositorios;
using System.IO;
using Projeto_ExercicioD3.Models;
using System.ComponentModel.DataAnnotations;

namespace Projeto_ExercicioD3
{
    internal class Program : Manipulacao_de_arquivo
    {
        static void Main(string[] args)
        {
            string caminho = "basededados/arquivo.txt";
            //A funcao CriaArquivo recebe um caminho e assegura de que o arquivo desejado exista
            CriaArquivo(caminho);

            RegistraAcesso registrador = new RegistraAcesso();

            //A lista DadosAcesso contem o email e a senha de todas as contas com acesso ao banco de dados
            List<string> DadosAcesso = new List<string> { "admin@email.comadmin123", "cursocsharp@email.comsenha123" };

            string entrada = null;

            while (entrada != "0")
            {
                Console.WriteLine("Escolha uma opção:\n");
                Console.WriteLine("1 - Acessar o banco de dados");
                Console.WriteLine("0 - Sair da operação\n");
                
                entrada = Console.ReadLine();

                if (entrada == "1")
                {
                    Usuario usuario = new Usuario();
                    string dados = null;
                    Console.WriteLine("Digite seu e-mail:");
                    usuario.Email = Console.ReadLine();
                    dados = usuario.Email;
                    Console.WriteLine("Digite sua senha:");
                    usuario.Senha = Console.ReadLine();
                    dados += usuario.Senha;
                    
                    if (DadosAcesso.Contains(dados)) 
                    {
                        usuario.Id = DadosAcesso.IndexOf(dados);
                        Console.WriteLine("Login bem-sucedido\n");

                        Console.WriteLine("Digite seu nome:");
                        usuario.Nome = Console.ReadLine();

                        //A logica abaixo escreve os dados do usuario no arquivo de texto
                        StreamWriter escritor = new StreamWriter(caminho, true);
                        DateTime agora = DateTime.Now;
                        string stringAgora = Convert.ToString(agora);
                        string hora = stringAgora.Split(" ")[1];
                        string data = stringAgora.Split(" ")[0];
                        escritor.WriteLine("O usuário {0} de Id {1} acessou o banco de dados as {2} do dia {3}", usuario.Nome, usuario.Id, hora, data);
                        escritor.Close();

                        //A funcao abaixo registra o usuario no banco de dados no servidor SQL
                        registrador.Registrar(usuario);

                        string opcao = null;
                        
                        while (opcao == null)
                        {
                            Console.WriteLine("Voce esta no banco de dados");
                            Console.WriteLine("Digite 0 para sair ou digite 2 para voltar");
                            opcao = Console.ReadLine();

                            if (opcao == "2")
                            {
                                entrada = null;
                            }
                            else if (opcao == "0")
                            {
                                entrada = "0";
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Credenciais invalidas\n");
                        entrada = null;
                    }
                }
            }
        }
    }
}