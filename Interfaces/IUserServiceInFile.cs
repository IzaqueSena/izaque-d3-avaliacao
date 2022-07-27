using izaque_d3_avaliacao.Models;

namespace izaque_d3_avaliacao.Interfaces
{
    internal interface IUserServiceInFile
    {
        public void WriteInFile(User user, bool login);
    }
}
