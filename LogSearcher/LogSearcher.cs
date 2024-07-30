using System;
using System.Collections.Generic;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Text.RegularExpressions;

public class LogSearcher
{
    public List<string> SearchLogs(string directoryPath, string searchPattern)
    {
        List<string> results = new List<string>();
        var files = Directory.GetFiles(directoryPath, "*.log");

        foreach (var file in files)
        {
            using (var mmf = MemoryMappedFile.CreateFromFile(file, FileMode.Open))
            {
                using (var stream = mmf.CreateViewStream())
                {
                    using (var reader = new StreamReader(stream))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            if (IsMatch(line, searchPattern))
                            {
                                results.Add(line);
                            }
                        }
                    }
                }
            }
        }

        return results;
    }

    private bool IsMatch(string line, string pattern)
    {
        pattern = "^" + Regex.Escape(pattern).Replace(@"\*", ".*").Replace(@"\?", ".") + "$";
        return Regex.IsMatch(line, pattern, RegexOptions.IgnoreCase);
    }
}
