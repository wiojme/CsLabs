using System;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
namespace Program;


class Programm
{
    public static void Main()
    {
        bool servproc = true;
        int servrep = 0;
        int servrel = 0;
        int serverr = 0;

        Console.WriteLine("====ПроверкаСервера====");
        Console.WriteLine("1) Запустить");
        Console.WriteLine("2) Выйти");
        string boof = Console.ReadLine();
        int varn = Convert.ToInt32(boof);
        Thread.Sleep(TimeSpan.FromSeconds(2));
        Console.Clear();
        if (varn == 1)
        {


            Console.WriteLine("====ПроверкаСервера====");
            if (servproc == false)
            {
                Console.WriteLine("Обнаружен сбой! \nТребуется вмещательство администратора!");
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
            }

            if (servrel <= 1)
            {
                Console.WriteLine("Сервер не был перезапущен.");
            }
            else
            {
                Console.WriteLine("Сервер был перезапущен аварийно! Проверьте исправность системы.");
            }

            if (serverr <= 0)
            {
                Console.WriteLine("Ошибок не обнаруженно.");
            }
            else
            {
                Console.WriteLine("Обнаруженны ошибки! Сообщить тех.администратору");
            }
            Thread.Sleep(TimeSpan.FromSeconds(5));
            Console.Clear();
        }

        else
        {
            Console.Clear();
            Environment.Exit(0);
        }
    }   
    

}

