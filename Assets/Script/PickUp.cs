using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//https://www.youtube.com/watch?v=_xMhkK6GTXA
public class PickUp : MonoBehaviour
{
   float throwForce = 600;
   Vector3 objectPos;
   float distance;

   public bool canHold= true;
   public GameObject item;
   public GameObject tempParent;
   public bool isHolding = false;


    
    // Update is called once per frame
    void Update()
    {

            distance = Vector3.Distance(item.transform.position, tempParent.transform.position);
            if(distance>= 1.5f)
            {
                    isHolding= false;
            }
        //Check if isHolding     
        if(isHolding == true)
        {
            //GameObject react with Collisions while Holding
             //item.GetComponent<Rigidbody>().velocity = Vector3.zero;
             //item.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
             item.GetComponent<Rigidbody>().isKinematic = true;
             item.transform.SetParent(tempParent.transform);
           
            
            //Right Click
            if(Input.GetMouseButtonDown(1))
            {
                //throw Obejct
                item.GetComponent<Rigidbody>().isKinematic = false;
                item.GetComponent<Rigidbody>().AddForce(tempParent.transform.forward * throwForce);
                isHolding =false;

                //Destroy Object after 1 sec
                Destroy(this.gameObject, 2f);
            }
        }
        else
        {
            objectPos = item.transform.position;
            item.transform.SetParent(null);
            item.GetComponent<Rigidbody>().useGravity = true;
            item.transform.position = objectPos;
        }
    }
    void OnMouseDown()
    {
        //PickUp range
        if(distance <=1.5f)
        {
        
        isHolding = true;
        item.GetComponent<Rigidbody>().useGravity = false;
        item.GetComponent<Rigidbody>().detectCollisions = true;

        //place Object into the Hands of the  Player
        //item.transform.position = tempParent.transform.position;
        //item.transform.parent = tempParent.transform;

        }
    }
    //Holding till Mousebutton is released
    void OnMouseUp()
    {
        isHolding = false;
    }

}
