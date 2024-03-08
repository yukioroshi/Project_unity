using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menubehavior : MonoBehaviour
{
    public Button bouton;

    // Start is called before the first frame update
    void Start()
    {
        bouton.onClick.AddListener(ActionOnClick);
    }

    void ActionOnClick()
    {
        SceneManager.LoadScene("mainscene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
