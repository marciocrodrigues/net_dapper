using Blog.Screens.TagScreens;
using Microsoft.Data.SqlClient;
using System;

namespace Blog
{
    public class Program
    {
        private static string CONNECTION_STRING_ID = Environment.GetEnvironmentVariable("CONNECTION_STRING_SQL_SERVER_ID", EnvironmentVariableTarget.Machine);
        private static string CONNECTION_STRING_PASSWORD = Environment.GetEnvironmentVariable("CONNECTION_STRING_SQL_SERVER_PASSWORD", EnvironmentVariableTarget.Machine);
        private static string connectionString = @$"Server=localhost, 1433;Database=Blog;User ID={CONNECTION_STRING_ID};Password={CONNECTION_STRING_PASSWORD};TrustServerCertificate=True";

        static void Main(string[] args)
        {
            Database.Connection = new SqlConnection(connectionString);
            Database.Connection.Open();
            
            Load();

            Console.ReadKey();
            Database.Connection.Close();
        }

        private static void Load()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Meu Blog");
            Console.WriteLine("--------------");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine();
            Console.WriteLine("1 - Gestão de usuário");
            Console.WriteLine("2 - Gestão de perfil");
            Console.WriteLine("3 - Gestão de categoria");
            Console.WriteLine("4 - Gestão de tag");
            Console.WriteLine("5 - Vincular perfil/usuário");
            Console.WriteLine("6 - Vincular post/tag");
            Console.WriteLine("7 - Relatórios");
            Console.WriteLine();
            Console.WriteLine();
            var option = short.Parse(Console.ReadLine()!);

            switch (option)
            {
                case 4:
                    MenuTagScreen.Load();
                    break;
                default: Load(); break;
            }
        }
    }
}
