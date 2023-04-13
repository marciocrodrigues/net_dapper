using Blog.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using System;

namespace Blog
{
    internal class Program
    {
        private const string CONNECTION_STRING = @"Server=localhost, 1433;Database=Blog;User ID=sa;Password=Mcro@093246;TrustServerCertificate=True";

        static void Main(string[] args)
        {
            ReadUsers();
            Console.ReadKey();
        }

        public static void ReadUsers()
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                var users = connection.GetAll<User>();

                foreach (var user in users)
                {
                    Console.WriteLine(user.Name);
                }
            }
        }

        public static void ReadUser(int id)
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                var user = connection.Get<User>(id);

                Console.WriteLine(user.Name);
            }
        }

        public static void CreateUser()
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

            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                var rowsAffecteds = connection.Insert<User>(user);

                Console.WriteLine($"Linhas afetadas: {rowsAffecteds}");
            }
        }

        public static void UpdateUser(int id)
        {
            var user = new User()
            {
                Id = id,
                Name = "Teste da Silva 2",
                Email = "teste2@teste.com.br",
                Bio = "Equipe TESTE 2",
                Image = "https://www.google.com.br",
                PasswordHash = "HASH",
                Slug = "equipe-teste-2"
            };

            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                var rowsAffecteds = connection.Update<User>(user);

                Console.WriteLine($"Linhas afetadas: {rowsAffecteds}");
            }
        }

        public static void DeleteUser(int id)
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                var user = connection.Get<User>(id);

                if (user != null)
                {
                    var rowsAffecteds = connection.Delete<User>(user);

                    Console.WriteLine($"Linhas afetadas: {rowsAffecteds}");
                }
            }
        }
    }
}
