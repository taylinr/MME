using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prefab_Script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(0, Mathf.Cos(Time.time) * 360, Mathf.Sin(Time.time) * 360);
    }
}
