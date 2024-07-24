using System;
using System.IO;

class Program
{
    static void Main()
    {
        Console.Write("Введите путь к файлу: ");
        string filePath = Console.ReadLine();

        if (!File.Exists(filePath))
        {
            Console.WriteLine("Файл не найден.");
            return;
        }

        Console.Write("Введите слово для поиска: ");
        string searchWord = Console.ReadLine();

        try
        {
            string content = File.ReadAllText(filePath);
            int count = CountWordOccurrences(content, searchWord);

            Console.WriteLine($"Слово '{searchWord}' встречается {count} раз(а) в файле.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при чтении файла: {ex.Message}");
        }
    }

    static int CountWordOccurrences(string text, string word)
    {
        if (string.IsNullOrWhiteSpace(word))
        {
            return 0;
        }

        int count = 0;
        int startIndex = 0;

        while ((startIndex = text.IndexOf(word, startIndex, StringComparison.OrdinalIgnoreCase)) != -1)
        {
            count++;
            startIndex += word.Length;
        }

        return count;
    }
}
