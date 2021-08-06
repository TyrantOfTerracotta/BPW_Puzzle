using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveProjectile : MonoBehaviour
{
    //PUBLICS
    public GameObject expl;
    public GameObject exp2;
    public float duration1;
    public float duration2;

    public float explForce;
    public float explRadius;

    private void OnCollisionEnter(Collision other) //Other means it doesnt matter what it hits, change to make more specific interactions
    {
        GameObject tempExpl = Instantiate(expl, transform.position, transform.rotation);
        GameObject tempExp2 = Instantiate(exp2, transform.position, transform.rotation);
        Destroy(tempExpl, duration1);
        Destroy(tempExp2, duration2);
        //knockBack();
        FindObjectOfType<AudioManager>().Play("ShardExplosion");
        Destroy(gameObject);
    }

    void knockBack()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explRadius); //creating an array ('list') for each object the knockback affects

        foreach (Collider nearby in colliders) //program going through each collision object
        {
            Rigidbody rb = nearby.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explForce, transform.position, explRadius);
            }
        }
    }
}
