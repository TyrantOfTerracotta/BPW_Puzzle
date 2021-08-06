using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cubeProjectileScript : MonoBehaviour
{

    //[SerializeField] public GameObject cube;


    void OnCollisionEnter(Collision col)
    {

            FindObjectOfType<AudioManager>().Play("ImpactCube");
        
    }
}
