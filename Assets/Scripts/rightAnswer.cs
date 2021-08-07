using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class rightAnswer : MonoBehaviour
{
    //public GameObject goldRespawnPoint;
    //public GameObject Player;
    public GameObject obstacle;


    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Projectile")
        {
            FindObjectOfType<AudioManager>().Play("UnlockSecret");

            Destroy(obstacle.gameObject);
            
            Debug.Log("Correct! Hooraay");
        }
    }
}
