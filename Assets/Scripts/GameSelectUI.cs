using TMPro;
using UnityEngine;

public class GameSelectUI : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Get games left from GameSelectStats
        GameSelectStats gameSelect = FindFirstObjectByType<GameSelectStats>();
        // Get total money from stats
        // TODO: Integrate with whatever system tracks money

        // Get UI Elements
        TMP_Text gamesLeftText =GameObject.Find("Games Left").GetComponent<TMP_Text>();
        TMP_Text MoneyText = GameObject.Find("Money UI").GetComponent<TMP_Text>();
        //update UI elements accordingly
        gamesLeftText.text = "Games Left: " + gameSelect.gamesLeft;
        MoneyText.text = "Money: $" + 100; // Placeholder value for money
    }

  
}
