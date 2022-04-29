using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//BombSolo and BombExplode need to be attached on an EmptyObject
public class BombSolo : MonoBehaviour
{
    public GameObject itemPrefab;

    //Spawn
    private GameObject item;
    public float throwForce = 20f;

    GameObject tempParent;
    private void Awake() 
    {
         tempParent = GameObject.FindWithTag("WeaponContainer");
    }

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

    //Aim
   void ThrowItem()
    {
        item = Instantiate(itemPrefab, tempParent.transform.position, tempParent.transform.rotation);//Create Item
       // item.GetComponent<Rigidbody>().isKinematic = true;
     //   item.transform.SetParent(tempParent.transform);// Set prefab as child
         
        //Reset Physics
       item.GetComponent<Rigidbody>().isKinematic = false;
        Rigidbody rb = item.GetComponent<Rigidbody>();
        //item.transform.SetParent(null);
        
        //Throw
        rb.AddForce(transform.forward * throwForce, ForceMode.VelocityChange);
    }

    void PlaceItem()
    {
        //Place Item where it was Initiate
        item = Instantiate(itemPrefab, tempParent.transform.position, tempParent.transform.rotation);
        item.GetComponent<Rigidbody>().isKinematic = true;
    }
}   
