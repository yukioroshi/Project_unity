using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goalPoints : MonoBehaviour
{
    Vector3 originalPos;
    [SerializeField] GameObject player1;

    // Start is called before the first frame update
    void Start()
    {
        originalPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.transform.name == "Player1")
        {
            score.ScoreR += 1;
            gameObject.transform.position = originalPos;
        }

        if (col.transform.name == "goalGb")
        {
            score.ScoreB += 1;
            gameObject.transform.position = originalPos;
            player1.transform.position = originalPos;
        }
    }
}
