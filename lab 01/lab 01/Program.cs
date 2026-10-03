using System;
namespace WpfLibrary2;

class WpfLibrary2
{
    public static void Main()
    {

        Random rand = new Random();


        short level = (short)rand.Next(1, 100);
        int gold = rand.Next(0, 10000);
        long exp = rand.Next(0, 1000000000);
        bool podpiska = rand.Next(0, 2) == 1;


        Console.WriteLine("=== Проверка данных после обновления сервера ===");
        Console.WriteLine($"Уровень игрока: {level}");
        Console.WriteLine($"Валюта: {gold}");
        Console.WriteLine($"Опыт: {exp}");
        Console.WriteLine($"Подписка: {podpiska}");



        int nalog = gold - (podpiska ? 100 : 200);
        long nextlevel = level * 1000L;
        short bonuslevel = podpiska ? (short)(level + 1) : level;



        bool serv = true;

        if (gold < 0)
        {
            Console.WriteLine("Ошибка: отрицательное количество валюты");
            serv = false;
        }

        if (exp < 0)
        {
            Console.WriteLine("Ошибка: отрицательный опыт!");
            serv = false;
        }

        if (bonuslevel <= 0)
        {
            Console.WriteLine("Ошибка: некорректный уровень персонажа!");
            serv = false;
        }

        if (serv)
        {
            Console.WriteLine("\n Все данные успешно проверены. Сервер готов к работе.");
        }
        else
        {
            Console.WriteLine("\n Проверка данных не пройдена. Требуется вмешательство администратора.");
        }
    }
}
