using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class player2Move : MonoBehaviour
{
    public Slider cursorBlue;

    private float horizontalInput;
    private float verticalInput;

    public float speed = 20f;
    public float jumpForce;

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
    public float forceMagnitude = 10f;
    public float detectionRadius = 5f;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        ballRB = ballObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal2");
        verticalInput = Input.GetAxis("Vertical2");

        rotate = horizontalInput * rotationspeed * Time.deltaTime;
        transform.Rotate(0f, rotate, 0f);

        //pousse la ball
        if (Vector3.Distance(transform.position, targetObject.position) < detectionRadius)
        {
            Vector3 direction = (targetObject.position - transform.position).normalized;

            if (Input.GetKeyDown(KeyCode.UpArrow) && stamina > 10)
            {
                ballRB.AddForce(direction * forceMagnitude, ForceMode.Impulse);
                stamina -= 10f;
            }
        }

        if (Input.GetKey(KeyCode.I))
        {
            playerRb.AddRelativeForce(Vector3.forward * speed, ForceMode.Acceleration);
            
        }
        if (Input.GetKey(KeyCode.K))
        {
            playerRb.AddRelativeForce(Vector3.back * speed, ForceMode.Acceleration);

        }

        if (Input.GetKey(KeyCode.RightShift) && Input.GetKey(KeyCode.I))
        {
            if (stamina > 0.2f)
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

        if (Input.GetKeyDown(KeyCode.RightAlt) && isonground)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isonground = false;
        }

        if (Input.GetKey(KeyCode.RightAlt) && !isonground)
        {
            if (stamina > 0.2f)
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

        if (isonground)
        {
            stamina += 0.05f;
        }
        if (stamina > staminamax)
        {
            stamina = staminamax;
        }

        cursorBlue.value = stamina;

    }

    IEnumerator sprintcd()
    {
        yield return new WaitForSeconds(3.0f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isonground = true;
        }
    }
}
