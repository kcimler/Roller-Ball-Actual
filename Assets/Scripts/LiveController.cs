using UnityEngine;
using System.Collections;

public class LiveController : MonoBehaviour {

    public int startingLives;
    public static int currentLives;
    public Vector3 currentSpawn;
    public Vector3 nextSpawn;
    public static GameObject player;

    public static bool gameOverTest = false;

    void Start()
    {
        currentLives = startingLives;
    }
    public bool gameOver()
    {
        if (!gameOverTest)
        {
            currentLives = currentLives - 1;
            if (currentLives < 0)
            {
                gameOverTest = true;
                transform.position = new Vector3(8.6f, 5.3f, -37);
            }
        }

        return gameOverTest;
    }

    public void Restart()
    {
        currentLives = startingLives;
    }
}
