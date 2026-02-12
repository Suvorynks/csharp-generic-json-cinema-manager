using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

// Модель даних
public class Viewer
{
    public string Name { get; set; } = string.Empty;
    public string MovieTitle { get; set; } = string.Empty;
}

public class Session
{
    public string MovieTitle { get; set; } = string.Empty;
    public string Time { get; set; } = string.Empty;
}

// Узагальнений клас для керування даними
public class DataManager<T> where T : class
{
    private readonly string _filePath;

    public DataManager(string filePath)
    {
        _filePath = filePath;
    }

    public void Save(List<T> data)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(data, options);
        File.WriteAllText(_filePath, json);
    }

    public List<T> Load()
    {
        if (!File.Exists(_filePath)) return new List<T>();
        string json = File.ReadAllText(_filePath);
        return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
    }
}

class Program
{
    static void Main()
    {
        var viewerManager = new DataManager<Viewer>("viewers.json");
        var viewers = viewerManager.Load();
        
        var sessions = new List<Session>
        {
            new Session { MovieTitle = "Oppenheimer", Time = "14:00" },
            new Session { MovieTitle = "Dune: Part Two", Time = "19:00" }
        };

        Console.WriteLine("=== CINEMA JSON MANAGER ===");
        Console.WriteLine("1. Переглянути розклад\n2. Купити квиток\n3. Вихiд");
        
        string? choice = Console.ReadLine();
        if (choice == "1")
        {
            sessions.ForEach(s => Console.WriteLine($"{s.MovieTitle} о {s.Time}"));
        }
        else if (choice == "2")
        {
            Console.Write("Ваше iм'я: ");
            string name = Console.ReadLine() ?? "Guest";
            viewers.Add(new Viewer { Name = name, MovieTitle = sessions[0].MovieTitle });
            viewerManager.Save(viewers);
            Console.WriteLine("Дані збережено у JSON!");
        }

        // Аналітика LINQ
        var loyalty = viewers.GroupBy(v => v.Name)
                             .Select(g => new { Name = g.Key, Count = g.Count() })
                             .OrderByDescending(x => x.Count);
        
        Console.WriteLine("\n--- Топ глядачiв (JSON Data) ---");
        foreach (var v in loyalty.Take(5)) Console.WriteLine($"{v.Name}: {v.Count} сеансiв");
    }
}
