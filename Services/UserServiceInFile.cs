using izaque_d3_avaliacao.Interfaces;
using izaque_d3_avaliacao.Models;

namespace izaque_d3_avaliacao.Services
{
    internal class UserServiceInFile : IUserServiceInFile
    {
        private const string path = "database/logins.csv";

        private FileManipulation fileManipulation;

        public UserServiceInFile()
        {
            fileManipulation = new(path);
        }

        /// <summary>
        /// Define a estrutura da linha do CSV
        /// </summary>
        /// <returns>Retorna a linha preparada para ser gravada</returns>
        private string prepareLine(User user, bool login)
        {
            if (login)
                return $"{user.IdUser};{user.Name};login;{user.LogInInstant.ToString("d")};{user.LogInInstant.ToString("T")}";
            else
                return $"{user.IdUser};{user.Name};logout;{user.LogOutInstant.ToString("d")};{user.LogOutInstant.ToString("T")}";
        }

        /// <summary>
        /// Cadastra um novo produto
        /// </summary>
        public void WriteInFile(User user, bool login)
        {
            string line = prepareLine(user, login);
            fileManipulation.appendLine(line);
        }
    }
}
