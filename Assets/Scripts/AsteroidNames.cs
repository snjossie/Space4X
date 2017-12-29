using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using UnityEngine;

public static class AsteroidNames
{
    private static readonly System.Random Random = new System.Random();

    private static readonly List<string> Names = new List<string>(128);

    static AsteroidNames()
    {
        InitializeNames();
    }

    public static void Reset()
    {
        Names.Clear();
        InitializeNames();
    }

    public static string RandomName()
    {
        var indexOfName = Random.Next(0, Names.Count);
        var name = Names[indexOfName];

        // prevent duplicate names
        Names.RemoveAt(indexOfName);

        if (!Names.Any())
        {
            Debug.Log("Used the asteroid name. Next name will be a duplicate.");
        }

        return name;
    }

    private static void InitializeNames()
    {
        var file = new FileInfo(Application.dataPath + @"/data/AsteroidNames.json");

        if (file.Exists)
        {
            var json = File.ReadAllText(file.FullName);
            var asteroidNames = JsonConvert.DeserializeObject<List<string>>(json);
            
            Names.AddRange(asteroidNames);
        }
        else
        {
            Debug.LogError("Could not locate asteroid names file at '" + file.FullName + "'");
            for (int i = 0; i < 1000; i++)
            {
                Names.Add("Asteroid " + i);
            }
        }
    }
}