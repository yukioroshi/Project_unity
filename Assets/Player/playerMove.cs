using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class playermove : MonoBehaviour
{

    public float speed;
    public float jumpForce;

    private float horizontalInput;
    private float forwardInput;

    private float rotate;
    public float rotationspeed;

    public bool isonground = true;

    private Rigidbody playerRb;

    public float stamina = 50;
    public float staminaConsumtion = 10;
    public bool isrunning = false;
    public float Cooldown = 5f;
    private float currentCooldown = 0f;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //get player input
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        

        //rotate the player
        rotate = horizontalInput * rotationspeed * Time.deltaTime;
        transform.Rotate(0f, rotate, 0f);

        //move the player forward
       if (Input.GetKey(KeyCode.E))
        {
            playerRb.AddRelativeForce(Vector3.forward * speed, ForceMode.Acceleration);
        }
        if (Input.GetKey(KeyCode.D))
        {
            playerRb.AddRelativeForce(Vector3.back * speed, ForceMode.Acceleration);
        }

        if(Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.E))
        {
            if(stamina >= 0 )
            {
                playerRb.AddRelativeForce(Vector3.forward * speed * 2, ForceMode.Acceleration);
                stamina -= staminaConsumtion * Time.deltaTime;
                isrunning = true;
                Debug.Log(stamina);
                
            }
            else
            {
                isrunning = false;
            }
        }
        else
        {
            isrunning = false;
        }

        if (stamina <= 0)
        {
            stamina = 0;
        }


        //let the player jump
        if (Input.GetKeyDown(KeyCode.Space) && isonground)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isonground = false;
        }
    }

   
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) 
        {
            isonground = true;
        }
    }

}
