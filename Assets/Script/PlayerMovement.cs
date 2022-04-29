using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody player;
    public float moveSpeed = 100f;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float xMove = Input.GetAxis("Horizontal");
        float zMove =  Input.GetAxis("Vertical");


        player.velocity = new Vector3(xMove * moveSpeed, player.velocity.y, zMove * moveSpeed) * Time.deltaTime;

    }
}
