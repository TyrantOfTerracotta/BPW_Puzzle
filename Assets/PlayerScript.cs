using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    //General player related
    public static float moveForce = 15f;
    public int jumpForce;
 
    private float directionY;
    public int canDoubleJump = 0;
    float tempY = 0;

    //Shooter related
    public GameObject skull;
    public Transform shooter;
    public float fireRate = 0f;
    public float fireForce = 0f;
    private float fireRateTimeStamp = 0f;

    public Rigidbody rbody;

    //Camera related
    public Camera camera;
    public float speedH = 2.0f;
    public float speedV = 2.0f;
    private float yaw = 0.0f;
    private float pitch = 0.0f;

    public bool dashBool;
    
    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody>();

        
        camera = GetComponentInChildren<Camera>();
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canDoubleJump < 2)  //OLD VERSION: "rbody.AddForce(new Vector3(0, jumpForce, 0));"
        {
            jump();
            tempY = jumpForce;
        }

        //CODE FOR THE GUN.
        if (Input.GetKey(KeyCode.Q))
        {
            if (Time.time > fireRateTimeStamp)
            {
                GameObject go = (GameObject)Instantiate(
                    skull, shooter.position, shooter.rotation);
                go.GetComponent<Rigidbody>().AddForce(shooter.forward * fireForce);
                fireRateTimeStamp = Time.time + fireRate;
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate() //FixedUpdate zorgt voor inconsistente jumps, waardoor de player soms later van de grond komt. Update is meer responsive, maar de player vibreert voordat hij de grond raakt.
    {
        float hor = Input.GetAxisRaw("Horizontal");
        float vert = Input.GetAxisRaw("Vertical");
        
        if (dashBool == false)
        {
            transform.position += (transform.forward * vert + transform.right * hor).normalized * Time.deltaTime * moveForce;
            rbody.velocity = new Vector3(hor, directionY, vert);
        }



        //CAMERA WITH MOUSE CONTROLLED
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");
        transform.rotation = Quaternion.Euler(0.0f, yaw, 0.0f);
        camera.transform.localRotation = Quaternion.Euler(pitch, 0.0f, 0.0f);
             
        
        tempY -= -Physics.gravity.y * Time.deltaTime;
        directionY = tempY;
    }

    void jump()
    {
        //FindObjectOfType<AudioManager>().Play("PlayerJump");
        canDoubleJump++;
        //rbody.AddForce(this.gameObject.transform.up * jumpForce);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Ground")
        {
            //indObjectOfType<AudioManager>().Play("ImpactGround");
            canDoubleJump = 0;
        }
        
    }
}
