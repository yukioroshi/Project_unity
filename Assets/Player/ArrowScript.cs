using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{

    [SerializeField] GameObject ball;
    Vector3 ballOrientation;
  //Quaternion orientation;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, (ball.transform.position - transform.position), Color.red);
        transform.LookAt(ball.transform);
       /* ballOrientation = (ball.transform.position - transform.position).normalized;
        orientation = new Quaternion(ballOrientation.x, ballOrientation.y, ballOrientation.z,0);
        transform.forward = ballOrientation;
        transform.rotation = orientation;*/

    }
}
