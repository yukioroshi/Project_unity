using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goalPoints : MonoBehaviour
{
    Vector3 originalPosBall;
    Vector3 originalPosPl1;
    Vector3 originalPosPl2;

    [SerializeField] GameObject player1;
    [SerializeField] GameObject player2;

    bool GOplayer1;

    // Start is called before the first frame update
    void Start()
    {
        originalPosBall = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        originalPosPl1 = new Vector3(453, 13, 453);
        originalPosPl2 = new Vector3(452, 13, 497);
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
            gameObject.transform.position = originalPosBall;
            player1.gameObject.transform.position = originalPosPl1;
            player2.gameObject.transform.position = originalPosPl2;
            player1.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
            player2.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (collision.transform.name == "goalGb")
        {
            score.ScoreB += 1;
            gameObject.transform.position = originalPosBall;
            player1.gameObject.transform.position = originalPosPl1;
            player2.gameObject.transform.position = originalPosPl2;
            player1.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
            player2.gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
