using Blog.Models;
using Blog.Repositories;
using System;
using System.Linq;

namespace Blog.Screens.TagScreens
{
    public static class ListTagsScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Lista de tags");
            Console.WriteLine("-------------");
            List();
            Console.ReadKey();
            MenuTagScreen.Load();
        }

        private static void List()
        {
            var repository = new Repository<Tag>(Database.Connection);
            var tags = repository.Get();

            if (tags.Count() > 0)
            {
                foreach (var item in tags)
                    Console.WriteLine($"{item.Id} - {item.Name} ({item.Slug})");
            } 
            else
            {
                Console.WriteLine("Nenhuma tag cadastrada!");
            }
            
        }
    }
}
