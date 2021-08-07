using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{

    public float sizeMultiplier;
    public float moveSpeed_Boost;

    public Transform powerupObject;

    public GameObject pickupEffect;
    public GameObject targetPlayer;

    private void Update()
    {
        powerupObject.Rotate(0f, 10f, 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Pickup(other);
        }
    }

    void Pickup(Collider player)
    {
        Debug.Log("Picked up a Powerup!");

        FindObjectOfType<AudioManager>().Play("Powerup");

        targetPlayer.GetComponent<PlayerScript>();
        PlayerScript.moveForce += moveSpeed_Boost;

        player.transform.localScale *= sizeMultiplier;

        // Cool effect spawn in
        Instantiate(pickupEffect, transform.position, transform.rotation);

        

            // Remove powerup object
        Destroy(gameObject);
    }
}
