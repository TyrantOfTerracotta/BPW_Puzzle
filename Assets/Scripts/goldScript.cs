using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goldScript : MonoBehaviour
{
    public GameObject goldRespawnPoint;
    public GameObject Player;



    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Projectile")
        {
            FindObjectOfType<AudioManager>().Play("PlayerDeath");

            Player.transform.position = goldRespawnPoint.transform.position;
            //SceneManager.LoadScene("Defeat");            
            Debug.Log("Wrong answer!");
            //Destroy(gameObject);
        }
    }
}
