using izaque_d3_avaliacao.Interfaces;
using izaque_d3_avaliacao.Models;
using izaque_d3_avaliacao.Repositories;
using izaque_d3_avaliacao.Services;

namespace izaque_d3_avaliacao
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IUserRepository userRepository = new UserRepository();
            IUserServiceInFile userServiceInFile = new UserServiceInFile();

            string option;
            do
            {
                Console.WriteLine("\nSISTEMA DE CADASTRO E REGISTRO DE ACESSO \n");
                Console.WriteLine("Digite 1 caso deseje acessar e 0 caso deseje cancelar.");
                option = Console.ReadLine();
                if (option == "1")
                {
                    bool authorized = false;
                    while (!authorized)
                    {
                        Console.WriteLine("Informe seu email: ");
                        string email = Console.ReadLine();
                        Console.WriteLine("Informe sua senha: ");
                        string password = Console.ReadLine();
                        if (email == "admin@email.com" && password == "admin123")
                        {
                            authorized = true;
                            Console.WriteLine("\nAcesso Autorizado!");
                            Console.WriteLine("Informe seu id: ");
                            string id = Console.ReadLine();
                            Console.WriteLine("Informe seu nome: ");
                            string name = Console.ReadLine();
                            User user = new()
                            {
                                IdUser = id,
                                Name = name,
                                Email = email,
                                Password = password,
                                LogInInstant = DateTime.Now
                            };
                            userRepository.Create(user);
                            userServiceInFile.WriteInFile(user, true);
                            Console.WriteLine("\nVocê foi cadastrado no banco de dados e seu acesso registrado em um arquivo.\n");
                            Console.WriteLine("Caso deseje deslogar digite 1 caso deseje encerrar o sistema digite 0\n");
                            option = Console.ReadLine();
                            user.LogOutInstant = DateTime.Now;
                            userServiceInFile.WriteInFile(user, false);
                        }
                        else
                            Console.WriteLine("Acesso não autorizado! Tente novamente\n");
                    }
                }
            } while (option == "1");
        }
    }
}