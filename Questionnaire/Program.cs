using System;

namespace Questionnaire
{
    class Program
    {
        static bool CheckNum(string number, out int corrnumber)
        {
            if (int.TryParse(number, out int intnum))
            {
                if (intnum > 0)
                {
                    corrnumber = intnum;
                    return false;
                }
            }
            {
                corrnumber = 0;
                return true;
            } 
        }
        static string[] NamesPets(int Amount)
        {
            var result = new string[Amount];
            for(int i = 0; i < Amount; i++)
            {
                Console.WriteLine("Введите имя питомца {0}", i+1);
                result[i] = Console.ReadLine();
            }
            return result;
        }
        static string[] FavoriteColors(int Amount)
        {
            var result = new string[Amount];
            for (int i = 0; i < Amount; i++)
            {
                Console.WriteLine("Введите любимый цвет {0}", i + 1);
                result[i] = Console.ReadLine();
            }
            return result;
        }
        static (string, string, int, bool, string[], int, string[]) GetUser()
        {
            (string Name, string LastName, int Age, bool HasPet, string[] NamesPets, int AmountColors, string[] FavColors) User;

            Console.WriteLine("Введите имя");
            User.Name = Console.ReadLine();
            Console.WriteLine("Введите фамилию");
            User.LastName = Console.ReadLine();

            int intage;
            do
            {
                Console.WriteLine("Введите возраст цифрами");
            }
            while (CheckNum(Console.ReadLine(), out intage));
            User.Age = intage;

            Console.WriteLine("Есть ли у вас животные? Введите: да или нет");
            int intAmountPet = 0;
            if (Console.ReadLine() == "да")
            {
                User.HasPet = true;
                do
                {
                    Console.WriteLine("Введите сколько у вас животных цифрами");
                }
                while (CheckNum(Console.ReadLine(), out intAmountPet));
                User.NamesPets = NamesPets(intAmountPet);
            }
            else
            {
                User.HasPet = false;
                User.NamesPets = null;
            }

            do
            {
                Console.WriteLine("Введите сколько у вас любимых цветов цифрами");
            }
            while (CheckNum(Console.ReadLine(), out User.AmountColors));
            User.FavColors = FavoriteColors(User.AmountColors);

            return User;
        }
        static void PrintUser((string Name, string LastName, int Age, bool HasPet, string[] NamesPets, 
            int AmountColors, string[] FavColors) user)
        {
            Console.WriteLine("Пользователь: {0} {1}, возраст: {2}, наличие питомцев: {3}, любимых цветов: {4}", 
                user.Name, user.LastName, user.Age, user.HasPet, user.AmountColors);
            
            if (user.HasPet == true)
            {
                Console.WriteLine("Имена питомцев:");
                foreach (var item in user.NamesPets)
                {
                    Console.WriteLine(item);
                }
            }
            
            Console.WriteLine("Любимые цвета:");
            foreach (var item in user.FavColors)
            {
                Console.WriteLine(item);
            }
        }
        static void Main(string[] args)
        {
            var user = GetUser();
            PrintUser(user);
        }
    }
}
