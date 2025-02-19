using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DictionaryExample : MonoBehaviour
{
    // name - string, score - int
    private Dictionary<string, int> _scoreboard;
    
    // id - int , item - GameObject
    private Dictionary<int, GameObject> _inventory;
    
    // Start is called before the first frame update
    void Start()
    {
        _scoreboard = new Dictionary<string, int>();
        
        _scoreboard.Add("Noel", 100);
        // This will be false, because it's not allowed to have the same key
        bool successfullyAdded = _scoreboard.TryAdd("Noel", 50);
        
        _scoreboard.Add("Jonathan", 1000);

        // Always do a check
        if (_scoreboard.ContainsKey("Matthew"))
        {
            var score = _scoreboard["Matthew"];
        }

        // Properly get value
        _scoreboard.TryGetValue("Matthew", out int score2);

        // Change value
        _scoreboard["Noel"] = 50;
        
        // Remove value
        _scoreboard.Remove("Noel");
    }
}
