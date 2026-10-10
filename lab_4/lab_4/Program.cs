using System;
using System.IO;
using System.Collections.Generic;

namespace lab__04
{

    struct LogEntry
    {
        public DateTime Timestamp;
        public string Level;
        public string Category;
        public string Message;
    }

    class Program
    {
        static void Main()
        {
            
            string[] lines = File.ReadAllLines("event_server.log");

            
            LogEntry[] entries = ParseLog(lines);

            
            var dateFilter = FilterByDate(entries, new DateTime(2026, 9, 1));
            var warningFilter = FilterByLevel(entries, "Warning");
            var serverFilter = FilterByCategory(entries, "Server");
            var searchResult = Search(entries, "маяк");
            int errorCount = CountByLevel(entries, "Error");

            
            string status = GetServerStatus(entries);

            
            Console.WriteLine("# Анализ логов игрового сервера");
            Console.WriteLine($"Записей за 01.09.2026: {dateFilter.Length}");
            Console.WriteLine($"Предупреждений [Warning]: {warningFilter.Length}");
            Console.WriteLine($"Записей категории Server: {serverFilter.Length}");
            Console.WriteLine($"Найдено упоминаний 'маяк': {searchResult.Length}");
            Console.WriteLine($"Количество ошибок [Error]: {errorCount}");
            Console.WriteLine($"Статус сервера: {status}");
        }

       
        static LogEntry[] ParseLog(string[] lines)
        {
            List<LogEntry> result = new List<LogEntry>();

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                
                int firstBracket = line.IndexOf('[');
                if (firstBracket < 0)
                    continue; 

                string timestampPart = line.Substring(0, firstBracket).Trim();
                string rest = line.Substring(firstBracket);

                DateTime timestamp;
               
                if (!DateTime.TryParseExact(timestampPart, "yyyy-MM-dd HH:mm:ss.fff",
                    System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None, out timestamp))
                {
                    continue; 
                }

                
                int secondBracket = rest.IndexOf(']');
                if (secondBracket < 0)
                    continue;

                string level = rest.Substring(1, secondBracket - 1);

                
                int thirdBracket = rest.IndexOf('[', secondBracket + 1);
                int fourthBracket = rest.IndexOf(']', thirdBracket + 1);

                if (thirdBracket < 0 || fourthBracket < 0)
                    continue;

                string category = rest.Substring(thirdBracket + 1, fourthBracket - thirdBracket - 1);

                
                string message = rest.Substring(fourthBracket + 1).Trim();

                result.Add(new LogEntry
                {
                    Timestamp = timestamp,
                    Level = level,
                    Category = category,
                    Message = message
                });
            }

            return result.ToArray();
        }

        
        static LogEntry[] FilterByDate(LogEntry[] entries, DateTime date)
        {
            date = date.Date; 
            List<LogEntry> filtered = new List<LogEntry>();

            foreach (var entry in entries)
            {
                if (entry.Timestamp.Date == date)
                {
                    filtered.Add(entry);
                }
            }

            return filtered.ToArray();
        }

        
        static LogEntry[] FilterByLevel(LogEntry[] entries, string level)
        {
            if (string.IsNullOrEmpty(level))
                return new LogEntry[0];

            string targetLevel = level.Trim().ToUpperInvariant();
            List<LogEntry> filtered = new List<LogEntry>();

            foreach (var entry in entries)
            {
                if (entry.Level.Trim().ToUpperInvariant() == targetLevel)
                {
                    filtered.Add(entry);
                }
            }

            return filtered.ToArray();
        }

        
        static LogEntry[] FilterByCategory(LogEntry[] entries, string category)
        {
            if (string.IsNullOrEmpty(category))
                return new LogEntry[0];

            string targetCategory = category.Trim().ToUpperInvariant();
            List<LogEntry> filtered = new List<LogEntry>();

            foreach (var entry in entries)
            {
                if (entry.Category.Trim().ToUpperInvariant() == targetCategory)
                {
                    filtered.Add(entry);
                }
            }

            return filtered.ToArray();
        }

        
        static LogEntry[] Search(LogEntry[] entries, string text)
        {
            if (string.IsNullOrEmpty(text))
                return new LogEntry[0];

            string searchText = text.ToLowerInvariant();
            List<LogEntry> filtered = new List<LogEntry>();

            foreach (var entry in entries)
            {
                if (entry.Message.ToLowerInvariant().Contains(searchText))
                {
                    filtered.Add(entry);
                }
            }

            return filtered.ToArray();
        }

        
        static int CountByLevel(LogEntry[] entries, string level)
        {
            return FilterByLevel(entries, level).Length;
        }

        
        static string GetServerStatus(LogEntry[] entries)
        {
            bool hasFatalServer = false;
            bool hasError = false;

            foreach (var entry in entries)
            {
                
                if (entry.Level.Equals("Fatal", StringComparison.OrdinalIgnoreCase) &&
                    entry.Category.Equals("Server", StringComparison.OrdinalIgnoreCase))
                {
                    hasFatalServer = true;
                }
                if (entry.Level.Equals("Error", StringComparison.OrdinalIgnoreCase))
                {
                    hasError = true;
                }
            }

            if (hasFatalServer)
            {
                return "КРИТИЧЕСКАЯ ОШИБКА: сервер остановлен";
            }
            else if (hasError)
            {
                return "Есть ошибки: требуется проверка";
            }
            else
            {
                return "Сервер работает штатно";
            }
        }
    }
}
