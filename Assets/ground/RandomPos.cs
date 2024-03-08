using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPos : MonoBehaviour
{
    public GameObject existingObject;

    public GameObject objectToPlace;

    public int numberOfObjectToPlace;

    public float minX = -5f;
    public float maxX = 5f;
    public float minZ = -5f;
    public float maxZ = 5f;

    public string LevelToLoad;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 existingObjectPosition = existingObject.transform.position;

        for (int i = 0; i < numberOfObjectToPlace; i++)
        {
            float randomX = Random.Range(minX, maxX);
            float randomZ = Random.Range(minZ, maxZ);

            Vector3 newPostion = existingObjectPosition + new Vector3(randomX, 0F, randomZ);

            Instantiate(objectToPlace, newPostion, Quaternion.Euler(45f,0f,0f));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
