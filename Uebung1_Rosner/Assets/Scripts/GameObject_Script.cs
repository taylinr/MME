using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameObject_Script : MonoBehaviour
{

    public Transform myPrefab;

    // Start is called before the first frame update
    void Start()
    {
        int objectCount = 5;

        for(int i = 0; i < objectCount; i++){
            Vector3 vector3 = new Vector3(UnityEngine.Random.Range(-10, 10), UnityEngine.Random.Range(-10, 10), UnityEngine.Random.Range(-10, 10));
            Instantiate(myPrefab, vector3, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}


