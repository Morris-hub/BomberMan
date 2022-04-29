using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{


    public GameObject Weapon;
    public GameObject Bullet;
    public bool ableToShoot = false;
    public int throwForce = 50;
    public int amountBullets=10;

    // Variables
    private Transform target;
    private Transform Emitter;
    private GameObject item;
    public float speed = 4f;

    Rigidbody rb;
    // GameObject player;
    float distance;

    void Start() 
    {   
        //Get Player 
        GameObject player = GameObject.Find("Player");
        target = player.GetComponent<Transform>();

        //Get Emiiter 
        Emitter = Weapon.gameObject.transform.GetChild(0);

        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {   
        //stage 1
        distance = Vector3.Distance(target.position, transform.position);


        if(distance <= 20 )
        {
            followTarget();
            if(ableToShoot == true)
            {
                InvokeRepeating("AttackMode",0f ,3f);
            }
        }
        else if(distance > 20 )
        {
            followTarget();
        }


      
    }

    void followTarget()
    {
        Vector3 pos = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);        
        rb.MovePosition(pos);
        transform.LookAt(target);
        //Debug.Log(distance);
    }
        void AttackMode()
        {
            if(item != enabled && Emitter == enabled){
            item =  Instantiate(Bullet,Emitter.position, Quaternion.identity);
            Rigidbody rb = item.GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * throwForce, ForceMode.VelocityChange);  
            }
            //FindObjectOfType<AudioManager>().Play("AlertSound");    
        }

       

        public void Patroulie()
        {
            //Walk in a specific distance or point than given
              //Vector3.Magnitude(transform.position);
            
        }


    /*
        void OnTriggerEnter(Collider collider)
        {
        //React when collid on  player(needs rigidbody)
        if(collider.gameObject.tag == "Bullet")
        {

                Debug.Log("Enemy killed");
            //Destroy Object if succesful
            Destroy(collider.gameObject);
        }
    }*/
}
