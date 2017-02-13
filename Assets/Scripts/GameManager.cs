using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	// make game manager public static so can access this from other scripts
	public static GameManager gm;

    // public variables

    public string thisLevelName = "";

    public string gameOverMenu = "LoseRollerBall";

    public Text livesDisplay;

	public float startTime=10.0f;
	
	public Text mainTimerDisplay;

	public AudioSource musicAudioSource;

	public bool gameIsOver = false;

	private float currentTime;

    public string playAgainLevelToLoad;

    public LiveController lives;

    public static GameObject player;

    public Rigidbody zero;


    // setup the game
    void Start () {

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        lives = player.GetComponent<LiveController>();

        // set the current time to the startTime specified
        currentTime = startTime;

		// get a reference to the GameManager component for use by other scripts
		if (gm == null) 
			gm = this.gameObject.GetComponent<GameManager>();
	}

	// this is the main game event loop
	void Update () {
        if (!gameIsOver) {
            if (currentTime < 0)
            { // check to see if timer has run out
                if (lives.gameOver())
                {
                    EndGame();
                }
                else
                {
                    mainTimerDisplay.text = 0.ToString("0.00");
                    GameObject player = GameObject.FindGameObjectWithTag("Player");
                    zero = player.GetComponent<Rigidbody>();
                    zero.velocity = Vector3.zero;
                    player.transform.position = new Vector3(0, 0, 0);
                    SceneManager.LoadScene(thisLevelName);
                }
            }
            else
            { // game playing state, so update the timer
                currentTime -= Time.deltaTime;
                mainTimerDisplay.text = currentTime.ToString("0.00");
                livesDisplay.text = LiveController.currentLives.ToString("0");
            }
		}
	}

	public void EndGame() {
        // game is over

		gameIsOver = true;

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = new Vector3(0, 0, 0);

        LiveController.gameOverTest = false;

        SceneManager.LoadScene(gameOverMenu);
    }

}

	
