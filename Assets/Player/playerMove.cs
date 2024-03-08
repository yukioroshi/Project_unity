using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class playermove : MonoBehaviour
{

    public Slider cursorRed;

    public float speed = 50f;
    public float jumpForce = 1000f;

    private float horizontalInput;
    private float forwardInput;

    private float rotate;
    public float rotationspeed;

    public bool isonground = true;

    private Rigidbody playerRb;

    //pour sprint et jetpack
    public float stamina = 50;
    public float staminamax = 50;
    public float staminaConsumtion = 10;
    public bool isrunning = false;

    //pour FOV
    public Camera mainCamera;
    public float finalFOV;
    public float durationFov;

    //pour pousser la ball
    public Transform targetObject;
    private Rigidbody ballRB;
    public GameObject ballObject;
    public float forceMagnitude = 60f;
    public float detectionRadius = 15f;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        ballRB = ballObject.GetComponent<Rigidbody>();
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

        //pousse la ball
        if (Vector3.Distance(transform.position, targetObject.position) < detectionRadius)
        {
            Vector3 direction = (targetObject.position - transform.position).normalized;

            if (Input.GetKeyDown(KeyCode.C) && stamina > 10) 
            {
                ballRB.AddForce(direction * forceMagnitude, ForceMode.Impulse);
                stamina -= 10f;
            }
        }

        //move the player forward
        if (Input.GetKey(KeyCode.E))
        {
            playerRb.AddRelativeForce(Vector3.forward * speed, ForceMode.Acceleration);
            
        }
        if (Input.GetKey(KeyCode.D))
        {
            playerRb.AddRelativeForce(Vector3.back * speed, ForceMode.Acceleration);
        }

        //sprint
        if(Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.E))
        {
            if(stamina > 0.2f)
            {
                playerRb.AddRelativeForce(Vector3.forward * speed * 2, ForceMode.Acceleration);
                stamina -= staminaConsumtion * Time.deltaTime * 2;
                mainCamera.fieldOfView = Mathf.Lerp(mainCamera.fieldOfView, 80, durationFov * Time.deltaTime);
                isrunning = true;
                //Debug.Log(stamina);
            }
            else
            {
                isrunning = false;
                StartCoroutine(sprintcd());
            }

        }
        else
        {
            mainCamera.fieldOfView = Mathf.Lerp(mainCamera.fieldOfView, 60, durationFov * Time.deltaTime);
            isrunning = false;
        }
        

        //let the player jump
        if (Input.GetKeyDown(KeyCode.Space) && isonground)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isonground = false;
        }

        //jetpack
        if (Input.GetKey(KeyCode.Space) && !isonground)
        {
            if ( stamina > 0.2f )
            {
                playerRb.AddForce(Vector3.up * speed, ForceMode.Acceleration);
                stamina -= staminaConsumtion * Time.deltaTime * 2;
                //Debug.Log(stamina);
            }

        }

        if (stamina <= 0)
        {
            stamina = 0;
        }

        //regen la stamina
        if (isonground)
        {
            stamina += 0.05f;
        }
        if (stamina > staminamax)
        {
            stamina = staminamax;
        }

        //link la valeur de stamina au slider
        cursorRed.value = stamina;
    }

    private void FixedUpdate()
    {

    }

    IEnumerator sprintcd()
    {
        yield return new WaitForSeconds(3.0f);
    }

    //detect la collision avec le sol
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) 
        {
            isonground = true;
        }
    }

}
