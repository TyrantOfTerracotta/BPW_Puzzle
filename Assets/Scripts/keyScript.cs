using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class keyScript : MonoBehaviour
{
    [SerializeField] public GameObject barrier;
    [SerializeField] public GameObject gateOrb;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            FindObjectOfType<AudioManager>().Play("KeyFound");
            Debug.Log("Picked one of the three keys! The matching door dissolved!");
            Destroy(barrier.gameObject);
            Destroy(gateOrb.gameObject);
            Destroy(this.gameObject);
        }
    }
}
