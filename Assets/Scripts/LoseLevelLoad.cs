using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoseLevelLoad : MonoBehaviour {

	public string nameOfLevelToLoad  = "";

    public GameObject player;

    public GameObject gm;

    public LiveController live;

    public GameManager gameManager;

    public Rigidbody zero;


	void OnTriggerEnter (Collider other)
	{
		if(other.gameObject.tag == "Player" )
		{
            player = GameObject.FindGameObjectWithTag("Player");
            live = player.GetComponent<LiveController>();
            if (live.gameOver())
            {
                gm = GameObject.FindGameObjectWithTag("GameManager");
                gameManager = gm.GetComponent<GameManager>();
                gameManager.EndGame();
            }
            else
            {
                zero = player.GetComponent<Rigidbody>();
                zero.velocity = Vector3.zero;
                player.transform.position = new Vector3(0,0,0);
                SceneManager.LoadScene(nameOfLevelToLoad);
            }
		}
	}
}
