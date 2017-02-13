using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

    public Rigidbody zero;
    public LiveController lives;
	
	public void LoadLevel(string name){
		Debug.Log ("Level load requested for: " + name);
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        lives = player.GetComponent<LiveController>();
        lives.Restart();
        zero = player.GetComponent<Rigidbody>();
        zero.velocity = Vector3.zero;
        player.transform.position = new Vector3(0, 0, 0);
        Application.LoadLevel(name);
	}
	
	public void quitLevel() {
		Debug.Log ("Quit function requested");
		Application.Quit();
	}
	
}
