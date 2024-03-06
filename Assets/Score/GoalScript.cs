using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Script a attacher aux cages*/
public class GoalScript : MonoBehaviour
{
    score score;
    Vector3 orignalBallPos;
  //  Rigidbody rb;
    


    // Start is called before the first frame update
    void Start()
    {
        orignalBallPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
    //    rb=GetComponent<Rigidbody>();
    //    rb.transform.position = orignalBallPos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball") && gameObject.CompareTag("GoalBlueGround"))
        {
            score.ScoreR++;
            other.transform.Translate(orignalBallPos);
            
        }
        if (other.CompareTag("Ball") && gameObject.CompareTag("GoalRedGround"))
        {
            score.ScoreB++;
            other.transform.Translate(orignalBallPos);
        }
        PlayerMove.setPlayerPos(PlayerMove.originalPosJ1,PlayerMove.originalPosJ2);
    }

}
