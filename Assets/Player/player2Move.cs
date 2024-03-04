using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player2Move : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;

    public float speed;
    public float jumpForce;

    private float rotate;
    public float rotationspeed;

    public bool isonground = true;

    private Rigidbody playerRb;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal2");
        verticalInput = Input.GetAxis("Vertical2");

        transform.Translate(Vector3.forward * Time.deltaTime * verticalInput * speed);

        rotate = horizontalInput * rotationspeed * Time.deltaTime;
        transform.Rotate(0f, rotate, 0f);


        if (Input.GetKeyDown(KeyCode.RightAlt) && isonground)
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
