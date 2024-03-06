using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{

    [SerializeField] GameObject ball;
    Quaternion orientation;
    Vector3 ballOrientation;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
       //Debug.DrawRay(transform.position, (ball.transform.position - transform.position), Color.red);
       ballOrientation = (ball.transform.position - transform.position);
       orientation = new Quaternion(ballOrientation.x+135f, ballOrientation.y, ballOrientation.z,0);
       transform.rotation = orientation;

    }
}
