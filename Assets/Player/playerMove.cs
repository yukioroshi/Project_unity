using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public bool isonground = true;
    private float horizontalInput;
    private float forwardInput;
    private static Rigidbody playerRb1;
    private static Rigidbody playerRb2;

    public static Vector3 originalPosJ1;
    public static Vector3 originalPosJ2;

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.CompareTag("Player1"))
        {
            originalPosJ1 = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
            playerRb1 = GetComponent<Rigidbody>();
        }
        if (gameObject.CompareTag("Player2"))
        {
            originalPosJ2 = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
            playerRb2 = GetComponent<Rigidbody>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //get player input
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        //Get camera normalized directional vectors
        Vector3 forward = GameObject.Find("PlayerCam").GetComponent<Camera>().transform.forward;
        Vector3 right = GameObject.Find("PlayerCam").GetComponent<Camera>().transform.right;
        forward.y = 0;
        right.y = 0;
        forward = forward.normalized;
        right = right.normalized;

        //create direction-relativ-input vectors
        Vector3 forwardRelativeVerticalInput = forwardInput * speed * 0.01f * forward;
        Vector3 rightRelativeHorizontalInput = horizontalInput * speed * 0.01f * right;

        //create and apply camera relative movement
        Vector3 cameraRelativeMovement = forwardRelativeVerticalInput + rightRelativeHorizontalInput;
        this.transform.Translate(cameraRelativeMovement, Space.World);

        //move the player forward
        //transform.Translate(Vector3.forward * Time.deltaTime * forwardInput);
        //transform.Translate(Vector3.right * Time.deltaTime * horizontalInput);
        //Debug.Log(speed);

        //let the player jump
        if (Input.GetKeyDown(KeyCode.Space) && isonground) 
        {
            playerRb1.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
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
    
    /*Place les joueurs dans leur positions d'origine: à appeler dans goalscript apres un but*/
  public static void setPlayerPos(Vector3 posPlayer1, Vector3 posPlayer2)
    {
        playerRb1.transform.position = posPlayer1;
        playerRb2.transform.position = posPlayer2;
    }


}
