using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform slime;
    public float smoothTime = 0.3f;
    public float yVelocity = 0.3f;

    public void Start()
    {
        
        slime = GameObject.FindGameObjectWithTag("Player").transform;
    }
    

    
    //Called after update
    public void LateUpdate()
    {
        //stores current cameras position in variable temp
        Vector3 temp = transform.position;

        //set camera's x position to match player's x position
        temp.x = slime.transform.position.x;
        
        //set camera's temp position to camera's current position
        transform.position = temp;
        
        if (slime.position.y >= 5)
        {
            //Smoothly move the camera up
            float newPosition = Mathf.SmoothDamp(transform.position.y, 7, ref yVelocity, smoothTime);
            transform.position = new Vector3(slime.position.x, newPosition, transform.position.z);
        }
        else
        {
            //Smoothly move the camera down
            float newPosition = Mathf.SmoothDamp(transform.position.y, 0, ref yVelocity, smoothTime);
            transform.position = new Vector3(slime.position.x, newPosition, transform.position.z);
        }
    }

    

}
