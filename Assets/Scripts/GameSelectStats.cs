using UnityEngine;

public class GameSelectStats : MonoBehaviour
{
    // Make it static to persist across scenes
    private static GameSelectStats instance;

    public int gamesLeft;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject); // Prevent duplication
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject); // Persist across scenes
        gamesLeft = 3;
    }

    public void finishedGame()
    {
        gamesLeft = gamesLeft - 1;
    }

    
}
