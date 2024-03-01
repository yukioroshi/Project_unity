using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class score : MonoBehaviour
{
    
    public static int ScoreR = 0;
    public static int ScoreB = 0;
    public TextMeshProUGUI scoreTred;
    public TextMeshProUGUI scoreTblue;

    // Start is called before the first frame update
    void Start()
    {
        scoreTblue.text = " - " + ScoreB;
        scoreTred.text = " - " + ScoreR;
    }

    // Update is called once per frame
    void Update()
    {
        scoreTblue.text = ScoreB + " - " + ScoreR;
        scoreTred.text = ScoreR + " - " + ScoreB;
    }

    
}
