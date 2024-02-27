using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermove : MonoBehaviour
{
    public float speed = 5.0f;
    public float jumpForce = 5.0f;
    private float horizontalInput;
    private float forwardInput;
    private Rigidbody playerRb;

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

        //move the player forward
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);

        //let the player jump
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }


    }
}
