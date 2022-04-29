using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//https://www.youtube.com/watch?v=_xMhkK6GTXA
public class SpawnInHand : MonoBehaviour
{
  

  
   public GameObject itemPrefab;
   private GameObject item;
   public float throwForce = 20f;
   public Transform tempParent;


    // Update is called once per frame
    void Update()
    {
       if(Input.GetMouseButtonDown(0))
       {
           ThrowItem();
       }
       else if(Input.GetMouseButtonDown(1))
       {
           PlaceItem();
       }
    }

   void ThrowItem()
    {
        item = Instantiate(itemPrefab, tempParent.position, tempParent.rotation);//Create Item
        item.GetComponent<Rigidbody>().isKinematic = true;
        item.transform.SetParent(tempParent.transform);// Set prefab as child
         //item.GetComponent<Rigidbody>().velocity = Vector3.zero;
         //item.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        
        //Reset Physics
        item.GetComponent<Rigidbody>().isKinematic = false;
        Rigidbody rb = item.GetComponent<Rigidbody>();
         item.transform.SetParent(null);
        
        //Throw
        rb.AddForce(transform.forward * throwForce, ForceMode.VelocityChange);
    }

    void PlaceItem()
    {
        //Place Item where it was Initiate
        item = Instantiate(itemPrefab, tempParent.position, tempParent.rotation);
        item.GetComponent<Rigidbody>().isKinematic = true;
    }
}   
