using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    public static int ScoreR = 0;
    public static int ScoreB = 0;
    public TextMeshProUGUI scoreTred;
    public TextMeshProUGUI scoreTblue;

    public float delai = 5f;

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

        if (Timer.TimeLeft <= 0 )
        {
            if ( ScoreR > ScoreB )
            {
                Timer.refTimer.text = "Red win";
                ChangerScene();
            }
            else if (ScoreR < ScoreB)
            {
                Timer.refTimer.text = "Blue win";
                ChangerScene();

            }
            else if( ScoreB == ScoreR )
            {
                Timer.refTimer.text = "Make an effort";
                Invoke("ChangerScene", delai);
            }
            ScoreR = 0;
            ScoreB = 0;

        }
    }

    void ChangerScene()
    {
        SceneManager.LoadScene("menu");
    }


}
