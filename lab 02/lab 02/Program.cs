using System;
using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
namespace Program;


class Programm
{
    public static void Main()
    {
       
        while (true)
        {
            Console.WriteLine("====ПроверкаСервера====");
            Console.WriteLine("1) Запустить");
            Console.WriteLine("2) Выйти");
            string boof = Console.ReadLine();

            Thread.Sleep(TimeSpan.FromSeconds(2));
            Console.Clear();
            if (int.TryParse(boof, out int vib))
            {

                switch (vib)
                {
                    case 1:
                        ServerCheck();
                        break;
                    case 2:
                        Console.Clear();
                        Environment.Exit(0);
                        break;
                }


                

            } 
        }
    }

    private static void ServerCheck()
    {
        Console.Write("Введите работает ли сервер? (true/false): ");
        bool.TryParse(Console.ReadLine(), out bool servproc);

        Console.Write("Введите число жалоб на сервер: ");
        int.TryParse(Console.ReadLine(), out int servrep);

        Console.Write("Введите число аварийных перезапусков сервера: ");
        int.TryParse(Console.ReadLine(), out int servrel);

        Console.Write("Введите число ошибок появившихся при запуске сервера: ");
        int.TryParse(Console.ReadLine(), out int serverr);
        Console.Clear();


        Console.WriteLine("====ПроверкаСервера====");
        int count = 0;
        if (servproc == false)
        {
            Console.WriteLine("Обнаружен сбой! \nТребуется вмещательство администратора!");
            count++;
        }
        else
        {
            Console.WriteLine("Сервер работает");
        }

        if (servrep <= 0)
        {
            Console.WriteLine("Жалоб не обнаруженно.");
        }
        else
        {
            Console.WriteLine("На сервер поступают неоднократные жалобы! Перезапустите сервер.");
            count++;
        }

        if (servrel <= 1)
        {
            Console.WriteLine("Сервер не был перезапущен.");
        }
        else
        {
            Console.WriteLine("Сервер был перезапущен аварийно! Проверьте исправность системы.");
            count++;
        }

        if (serverr <= 0)
        {
            Console.WriteLine("Ошибок не обнаруженно.");
        }
        else
        {
            Console.WriteLine("Обнаруженны ошибки! Сообщить тех.администратору");
            count++;
        }


        Console.Clear();
        Console.WriteLine();
        if (count == 0)
        {
            Console.Write("Сервер готов к запуску.");
        }
        else if (count >= 1 || count <= 2)
        {
            Console.Write("Запуск сервера с ограничениями.");
        }
        else 
        {
            Console.Write("Запуск сервера невозможен.");
        }
        Thread.Sleep(TimeSpan.FromSeconds(10));
        Environment.Exit(0);

    }














}