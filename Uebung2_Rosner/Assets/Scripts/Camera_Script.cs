using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Script : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
    public bool playerCoupling;

    // Start is called before the first frame update
    void Start () 
    {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position - player.transform.position;
        
    }

    void LateUpdate () 
    {
         if (playerCoupling) {
            Vector3 offsetRotated = player.transform.rotation * offset;
            transform.position = player.transform.position + offsetRotated;
            Vector3 targetDirection = player.transform.position - transform.position;
            transform.rotation = Quaternion.LookRotation(targetDirection, Vector3.up);
         } 
    }
}
