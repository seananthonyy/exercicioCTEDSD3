namespace Projeto_ExercicioD3.Repositorios
{
    internal class Manipulacao_de_arquivo
    {
        static public void CriaArquivo(string caminho)
        {
            
            string pasta = caminho.Split("/")[0];
            if (!Directory.Exists(pasta))
            {
                Directory.CreateDirectory(pasta);
            }

            if (!File.Exists(caminho))
            {
                File.Create(caminho).Close();
            }
        
        }
    }
}
