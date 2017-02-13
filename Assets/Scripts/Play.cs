using UnityEngine;
using System.Collections;

public class PlayGame : MonoBehaviour {

    public GameObject player;

    public void playGame()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Instantiate(player, transform.position = new Vector3(8.6f, 5.3f, -37f), Quaternion.identity);
    }
}
