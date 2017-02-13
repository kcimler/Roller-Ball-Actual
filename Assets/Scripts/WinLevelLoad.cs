using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class WinLevelLoad : MonoBehaviour
{

    public string nameOfLevelToLoad = "";

    public GameObject player;

    public LiveController live;

    public Rigidbody zero;


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player = GameObject.FindGameObjectWithTag("Player");
            live = player.GetComponent<LiveController>();
            zero = player.GetComponent<Rigidbody>();
            zero.velocity = Vector3.zero;
            player.transform.position = new Vector3(0,0,0);
            SceneManager.LoadScene(nameOfLevelToLoad);
           
        }
    }
}
