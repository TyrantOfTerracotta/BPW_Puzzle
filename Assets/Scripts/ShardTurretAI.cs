using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShardTurretAI : MonoBehaviour
{
    public Rigidbody bullet;
    public Transform barrelEnd;
    public Transform aimingTowards;
    
    public float fireForce = 0f;
    public float lifeTimeBullet;
    public float deltaFireRate;
    public float cooldownTime;

    public bool cd;

    void Update()
    {
        barrelEnd.transform.LookAt(aimingTowards);
            
        if (cd == false)
        {
            deltaFireRate += Time.deltaTime;
            if (deltaFireRate >= 1.0)
            {
                FindObjectOfType<AudioManager>().Play("TurretShot");

                //Shooting
                Rigidbody bulletInstance;
                bulletInstance = Instantiate(bullet, barrelEnd.position, barrelEnd.rotation);
                bulletInstance.AddForce(barrelEnd.forward * fireForce);
                Destroy(bulletInstance.gameObject, lifeTimeBullet);


                StartCoroutine(bulletTimer());
                deltaFireRate = 0;
            }
        }
    }

    IEnumerator bulletTimer()
    {
        cd = true;
        yield return new WaitForSeconds(cooldownTime);
        cd = false;
    }
}
