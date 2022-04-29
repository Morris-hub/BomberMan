using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateItem : MonoBehaviour
{

    public int rotateSpeed = 25;
    // Update is called once per frame
     PlayerCoin playerCoin;
    void Update()
    {
        //360 Grad dreheung in der  Y_Achse 
        transform.Rotate(0 ,10 * rotateSpeed * Time.deltaTime, 0);
    }

     void OnCollisionEnter(Collision other)
    {

        if ( other.gameObject.name == "Player")
        {

            playerCoin = other.gameObject.GetComponent<PlayerCoin>();
            playerCoin.collectedCoin+= 10;
    


            FindObjectOfType<AudioManager>().Play("CoinSound");
          
           Destroy(this.gameObject);
        }
    }
}
