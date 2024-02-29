using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goalPoints : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name == "goalGr")
        {
            score.ScoreR += 1;
        }

        if (collision.transform.name == "goalGb")
        {
            score.ScoreB += 1;
            Destroy(gameObject);
        }
    }

    
}
