using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player2Move : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    public float speed;
    public float jumpForce;
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
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.I))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * verticalInput);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            transform.Translate(Vector3.right * Time.deltaTime * horizontalInput);
        }
        

        if (Input.GetKeyDown(KeyCode.RightShift) && isonground)
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
