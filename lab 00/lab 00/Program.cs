using System;
using System.ComponentModel.Design;
namespace Program;


 class Programm
 {
    public static void Main()
    {
        Console.WriteLine("Привет игрок, заполни свой профиль, чтобы начать!");
        string level = "0";
        Console.Write("Введите ваше имя: ");
        string name = Console.ReadLine();
        Console.Clear();

        Console.Write($"{name}, укажи свой возраст: ");
        string buffer = Console.ReadLine();
        int age = Convert.ToInt32(buffer);
        Console.Clear();

        Console.Write("Укажите страну: ");
        string cou = Console.ReadLine();
        Console.Clear();
        Console.WriteLine("Добро пожаловать!");
        Console.WriteLine("Выберите действие:");
        Console.WriteLine("1) Загрузить профиль");
        Console.WriteLine("2) Выбрать язык");
        Console.WriteLine("3) Выйти");
        string temp = Console.ReadLine();
        int menu = Convert.ToInt32(temp);
        if (menu == 1)
        {
            Console.Clear();
            Console.WriteLine("=====ПРОФИЛЬ=====");
            Console.WriteLine($"Имя.......{name}");
            Console.WriteLine($"Возраст....{age}");
            Console.WriteLine($"Страна.....{cou}");
            Console.WriteLine($"Уровень..{level}");
            Console.WriteLine("=================");
        }
            if (menu == 2)
            {
                Console.Clear();
                Console.WriteLine("Языки:");
                Console.WriteLine("1) Английский");               
              
            }
                string laug = Console.ReadLine();
                int grp = Convert.ToInt32(laug);
                if (grp == 1)
                        {
                        Console.Clear();
                        Console.WriteLine("=====ПРОФИЛЬ=====");
                        Console.WriteLine($"Name......{name}");
                        Console.WriteLine($"Age........{age}");
                        Console.WriteLine($"Country....{cou}");
                        Console.WriteLine($"Level....{level}");
                        Console.WriteLine("=================");
                        }
                
            else
                {
                 Console.Write("bb(");
                }
    
                
 
       


    }

}