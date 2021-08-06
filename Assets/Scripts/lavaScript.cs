using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lavaScript : MonoBehaviour
{
    public GameObject lavaRespawnPoint;
    public GameObject Player;



    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            FindObjectOfType<AudioManager>().Play("PlayerDeath");

            Player.transform.position = lavaRespawnPoint.transform.position;
            //SceneManager.LoadScene("Defeat");            
            Debug.Log("HOT, HOT, HOOOT!");
            //Destroy(gameObject);
        }
    }
}
