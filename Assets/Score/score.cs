using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class score : MonoBehaviour
{
    public static float ScoreR = 0;
    public static float ScoreB = 0;
    public TextMeshProUGUI scoreTred;
    public TextMeshProUGUI scoreTblue;

    // Start is called before the first frame update
    void Start()
    {
        scoreTblue.text = "Score: " + ScoreB;
        scoreTred.text = "Score: " + ScoreR; 
        
    }

    public void UpdateScore(int scoreToAdd)
    {
        ScoreR += scoreToAdd;
        scoreTred.text = "Score: " + ScoreR.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        //UpdateScore(1);
    }

    private void OnGUI()
    {
        GUI.Box(new Rect (100,100,100,100 ), ScoreR.ToString());
    }

    
}
