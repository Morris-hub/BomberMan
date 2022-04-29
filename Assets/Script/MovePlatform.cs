using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{

    public Transform startMarker;
    public Transform endMarker;


    public float speed = 1.0f;
    public float journeyLength = 1.0f;
    private float startTime;

    //private bool playerReady = false;

    public bool loop = false;



    // Update is called once per frame
    void Update()
    {
        Movement();
      
    }
    /*
     void OnCollisionEnter(Collision other) 
    {
         if(other.gameObject.name == "Player")
         {
             GameObject player = other.gameObject;
             other.gameObject.transform.parent = this.transform; //set player as children
            Debug.Log("Collison");
             playerReady = true;
         }
         else 
        {
             this.transform.parent = null;
        }
    }
*/
        void Movement()
        {
            if(!loop)
            {
             float distCovered = (Time.time - startTime)* speed;
             transform.position = Vector3.Lerp(startMarker.position, endMarker.position, distCovered / journeyLength);  
            }
            if(loop)
            {
                float distCovered = Mathf.PingPong(Time.time - startTime, journeyLength/ speed);
                transform.position = Vector3.Lerp(startMarker.position, endMarker.position, distCovered/ journeyLength);
            }

        }
  
    
}
