using System;
using System.IO;

namespace lab__03;

class Program
{
    static void Main()
    {
        string[] lines = File.ReadAllLines("event_server.log");

        DateTime eventDate = GetEventDate(lines);
        string winner = GetWinner(lines);
        int winnerPoints = GetWinnerPoints(lines, winner);
        string lootItem = GetLootItem(lines, winner);
        int Reward = GetConsolationReward(lines);
        int warningCount = CountWarnings(lines);
        int errorCount = CountErrors(lines);

        Console.WriteLine("# Итоги события: Восстание Ледяного Пламени");
        Console.WriteLine($"Дата: {eventDate:dd.MM.yyyy}");
        Console.WriteLine($"Победитель: {winner}");
        Console.WriteLine($"Очки победителя: {winnerPoints}");
        Console.WriteLine($"Ивентовый предмет: {lootItem}");
        Console.WriteLine($"Утешительная награда Железных волков: {Reward} очков");
        Console.WriteLine($"Предупреждений во время события: {warningCount}");
        Console.WriteLine($"Ошибок во время события: {errorCount}");
    }

    static DateTime GetEventDate(string[] lines)
    {
        foreach (string line in lines)
        {
            if (line.Contains("Событие началось:"))
            {
                string datePart = line.Substring(0, 10);
                return DateTime.Parse(datePart);
            }
        }
        return DateTime.MinValue; 
    }

    static string GetWinner(string[] lines)
    {
        foreach (string line in lines)
        {
            if (line.Contains("объявлены победителями события"))
            {
                int searchTextStart = line.IndexOf("] ") + 2;
                int searchTextEnd = line.IndexOf(" объявлены победителями");

                if (searchTextStart < searchTextEnd && searchTextEnd > 0)
                {
                    return line.Substring(searchTextStart, searchTextEnd - searchTextStart);
                }
            }
        }
        return "Неизвестно";
    }

    static int GetWinnerPoints(string[] lines, string winner)
    {
        string searchText = $"{winner} получили ";

        foreach (string line in lines)
        {
            if (line.Contains(searchText) && line.Contains("очков события"))
            {
                int start = line.IndexOf(searchText) + searchText.Length;
                int end = line.IndexOf(" очков", start);

                if (start < end && end > 0)
                {
                    string pointsStr = line.Substring(start, end - start);
                    if (int.TryParse(pointsStr, out int points))
                    {
                        return points;
                    }
                }
            }
        }
        return 0;
    }

    static string GetLootItem(string[] lines, string winner)
    {
        string searchText = $"{winner} получили ивентовый предмет:";

        foreach (string line in lines)
        {
            if (line.Contains(searchText))
            {
                int startIndex = line.IndexOf(searchText) + searchText.Length;

                if (startIndex < line.Length)
                {
                    string item = line.Substring(startIndex).Trim();
                    return item;
                }
            }
        }
        return "Не получен";
    }

    static int GetConsolationReward(string[] lines)
    {
        string searchText = "утешительную награду:";

        foreach (string line in lines)
        {
            if (line.Contains(searchText))
            {
                int start = line.IndexOf(searchText) + searchText.Length;
                int end = line.IndexOf(" очков", start);

                if (start < end && end > 0)
                {
                    string rewardStr = line.Substring(start, end - start).Trim();
                    if (int.TryParse(rewardStr, out int reward))
                    {
                        return reward;
                    }
                }
            }
        }
        return 0;
    }


    static int CountWarnings(string[] lines)
    {
        bool EventRun = false;
        int count = 0;

        foreach (string line in lines)
        {
            if (line.Contains("Событие началось:"))
            {
                EventRun = true;
            }

            
            if (EventRun && line.Contains("[Warning]"))
            {
                count++;
            }

            
            if (line.Contains("Событие \"Восстание Ледяного Пламени\" закрыто"))
            {
                EventRun = false;
            }
        }

        return count;
    }

    static int CountErrors(string[] lines)
    {
        bool EventRun = false;
        int count = 0;

        foreach (string line in lines)
        {
            if (line.Contains("Событие началось:"))
            {
                EventRun = true;
            }

            if (EventRun && line.Contains("[Error]"))
            {
                count++;
            }

            if (line.Contains("Событие \"Восстание Ледяного Пламени\" закрыто"))
            {
                EventRun = false;
            }
        }

        return count;
    }
}
