using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string directoryPath;
        while (true)
        {
            Console.WriteLine("Enter the directory path:");
            directoryPath = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(directoryPath))
            {
                Console.WriteLine("Directory path cannot be empty. Please enter a valid directory path.");
                continue;
            }

            if (!Directory.Exists(directoryPath))
            {
                Console.WriteLine("Directory does not exist. Please enter a valid directory path.");
                continue;
            }

            break;
        }

        string searchPattern;
        while (true)
        {
            Console.WriteLine("Enter the search pattern:");
            searchPattern = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(searchPattern))
            {
                Console.WriteLine("Search pattern cannot be empty. Please enter a valid search pattern.");
                continue;
            }

            break;
        }

        LogSearcher searcher = new LogSearcher();
        var results = searcher.SearchLogs(directoryPath, searchPattern);

        foreach (var result in results)
        {
            Console.WriteLine(result);
        }
    }
}
