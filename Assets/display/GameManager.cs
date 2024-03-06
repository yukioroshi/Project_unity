using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    Vector3 originalPos;

    private void Awake()
    {
        if (Instance == null)
        {
            //Debug.LogError("trop d'unstance gamemanager dans la scène");
            //return;
        }

        Instance = this;
    }

    public void InitGame()
    {
        
    }

    public void ResetPos()
    {
        gameObject.transform.position = originalPos;
    }

    // Start is called before the first frame update
    void Start()
    {
        originalPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
