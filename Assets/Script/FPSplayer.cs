using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSplayer : MonoBehaviour
{
    public float speed = 100f;
    float zMov;
    float xMov;
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        xMov = Input.GetAxisRaw("Horizontal");
        zMov = Input.GetAxisRaw("Vertical");

        //Player walke in local direction
        Vector3 localVelocity = new Vector3(xMov * speed, rb.velocity.y, zMov * speed);
        rb.velocity = transform.TransformDirection(localVelocity);

    }

}
