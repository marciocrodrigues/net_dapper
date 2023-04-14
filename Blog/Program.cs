using Blog.Models;
using Blog.Repositories;
using Microsoft.Data.SqlClient;
using System;

namespace Blog
{
    internal class Program
    {
        private const string CONNECTION_STRING = @"Server=localhost, 1433;Database=Blog;User ID=sa;Password=Mcro@093246;TrustServerCertificate=True";

        static void Main(string[] args)
        {
            var connection = new SqlConnection(CONNECTION_STRING);
            connection.Open();

            ReadUsersWithRoles(connection);

            Console.ReadKey();

            connection.Close();
        }

        static void ReadUsersWithRoles(SqlConnection connection)
        {
            var userRepository = new UserRepository(connection);
            var users = userRepository.GetWithRoles();

            foreach (var user in users)
            {
                Console.WriteLine(user.Name);

                foreach (var role in user.Roles)
                {
                    Console.WriteLine(role.Name);
                }
            }
        }

        static void ReadRoles(SqlConnection connection)
        {
            var repository = new Repository<Role>(connection);
            var roles = repository.Get();

            foreach (var role in roles)
                Console.WriteLine(role.Name);
        }

        static void CreateUser(SqlConnection connection)
        {
            var user = new User()
            {
                Name = "Teste da Silva",
                Email = "teste@teste.com.br",
                Bio = "Equipe TESTE",
                Image = "https://www.google.com.br",
                PasswordHash = "HASH",
                Slug = "equipe-teste"
            };

            var userRepository = new Repository<User>(connection);
            userRepository.Create(user);
        }
    }
}
